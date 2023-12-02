using ACSystem.Application.Contracts.Persistence;
using ACSystem.Application.DTOs.Employee;
using ACSystem.Application.DTOs.Letter;
using ACSystem.Application.DTOs.LetterAttach;
using ACSystem.Application.DTOs.LetterNote;
using ACSystem.Application.DTOs.LetterReference;
using ACSystem.Application.Features.LetterReference.Requests.Queries;
using ACSystem.Application.Responses;
using ACSystem.Domain.Entity;
using ACSystem.Infrastructure.Const;
using ACSystem.Infrastructure.Utilities;
using AutoMapper;
using LinqKit;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.Features.LetterReference.Handlers.Queries
{
    public class GetLetterReferenceReportListRequestHandler : IRequestHandler<GetLetterReferenceReportListRequest, BaseCommandResponse>
    {
        private const string LetterReferenceReportList = "LetterReferenceReportList";

        private readonly ILetterReferenceRepository _letterReferenceRepository;
        private readonly ILetterAttachRepository _letterAttachRepository;
        private readonly IMapper _mapper;
        private readonly ILetterNoteRepository _letterNoteRepository;
        private readonly IMemoryCache _cache;

        public GetLetterReferenceReportListRequestHandler(ILetterReferenceRepository letterReferenceRepository,
                                                         IMapper mapper, IMemoryCache cache,
                                                         ILetterNoteRepository letterNoteRepository,
                                                         ILetterAttachRepository letterAttachRepository)
        {
            _letterReferenceRepository = letterReferenceRepository;
            _letterAttachRepository = letterAttachRepository;
            _mapper = mapper;
            _cache = cache;
            _letterNoteRepository = letterNoteRepository;

        }


        public async Task<BaseCommandResponse> Handle(GetLetterReferenceReportListRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                if(request.Page < 1)
                    request.Page = 1; 

                int page = request.Page;
                int skip  = (page - 1) * DefaultConst.TakeCount;


                #region predicate
                var predicate = PredicateBuilder.New<Domain.Entity.LetterReference>(true);

                if (!string.IsNullOrEmpty(request.LetterReferenceReportFilterDto.Title))
                    predicate.And(a=>a.Letter.Title.Contains(request.LetterReferenceReportFilterDto.Title));


                if (!string.IsNullOrEmpty(request.LetterReferenceReportFilterDto.Code))
                    predicate.And(a => a.Letter.Code.Contains(request.LetterReferenceReportFilterDto.Code));


                if (!string.IsNullOrEmpty(request.LetterReferenceReportFilterDto.SenderName))
                    predicate.And(a => a.FromEmployee.FirstName.Contains(request.LetterReferenceReportFilterDto.SenderName)||
                                       a.FromEmployee.LastName.Contains(request.LetterReferenceReportFilterDto.SenderName));



                if (!string.IsNullOrEmpty(request.LetterReferenceReportFilterDto.SenderEmail))
                    predicate.And(a => a.FromEmployee.Email.Contains(request.LetterReferenceReportFilterDto.SenderEmail));



                if (!string.IsNullOrEmpty(request.LetterReferenceReportFilterDto.SenderIdCode))
                    predicate.And(a => a.FromEmployee.IdentityCode.Contains(request.LetterReferenceReportFilterDto.SenderIdCode));



                if (!string.IsNullOrEmpty(request.LetterReferenceReportFilterDto.Date))
                    predicate.And(a => a.CreateDateMl.Date == request.LetterReferenceReportFilterDto.Date.ShamsiToMiladi());

                #endregion predicate


                if (_cache.TryGetValue(LetterReferenceReportList, out IEnumerable<Domain.Entity.LetterReference> letterReferencesReport))
                {

                }
                else
                {

                     letterReferencesReport = await _letterReferenceRepository.GetAllAsyncWithPaging(predicate, skip,
                                                      DefaultConst.TakeCount,
                                                      "Letter,FromEmployee,ToEmployee",
                                                      cancellationToken);


                    _cache.Set(LetterReferenceReportList, letterReferencesReport, TimeSpan.FromSeconds(DefaultConst.CashTimeOut));
                }



                var data = letterReferencesReport.Select(a => new GetLetterReferenceInfoDto
                {
                    Attaches = a.attaches.Select(a => new GetLetterAttahchInfoDto { FileName = a.FileUrl }).ToList(),
                    FromEmployee = _mapper.Map<GetEmployeeDto>(a.FromEmployee),
                    ToEmployee = _mapper.Map<GetEmployeeDto>(a.ToEmployee),
                    letter = _mapper.Map<GetLetterDto>(a.Letter),
                    ReplyText = a.ReplyText,
                    CreateDateMl = a.CreateDateMl,
                    CreateDateSh = a.CreateDateSh,
                    LetterNotes = _mapper.Map<List<GetLetterNoteDto>>(_letterNoteRepository.GetAll(a => a.LetterId == a.LetterId, cancellationToken)),

                }).ToList();


                var result = new GetLetterReferencesListWithPagingDto
                {
                    list = data,
                    page = page,
                };



                response.Success(data: result);

                
            }
            catch (Exception)
            {

                throw;
            }


            return response;




        }

    }
}
