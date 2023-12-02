using ACSystem.Application.Contracts.Persistence;
using ACSystem.Application.DTOs.Employee;
using ACSystem.Application.DTOs.Letter;
using ACSystem.Application.DTOs.LetterAttach;
using ACSystem.Application.DTOs.LetterNote;
using ACSystem.Application.DTOs.LetterReference;
using ACSystem.Application.DTOs.LetterReference.Validator;
using ACSystem.Application.Features.LetterReference.Requests.Queries;
using ACSystem.Application.Responses;
using ACSystem.Infrastructure.Const;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.Features.LetterReference.Handlers.Queries
{
    public class GetExportedLetterReferenceListRequestHandler : IRequestHandler<GetExportedLetterReferenceListRequest, BaseCommandResponse>
    {
        private const string ExportedLetterReferenceList = "ExportedLetterReferenceList";

        private readonly ILetterReferenceRepository _letterReferenceRepository;
        private readonly ILetterAttachRepository _letterAttachRepository;
        private readonly ILetterNoteRepository _letterNoteRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetExportedLetterReferenceListRequestHandler(ILetterReferenceRepository letterReferenceRepository,
                                                         IMapper mapper, IMemoryCache cache, ILetterNoteRepository letterNoteRepository,
                                                         ILetterAttachRepository letterAttachRepository)
        {
            _letterReferenceRepository = letterReferenceRepository;
            _letterAttachRepository = letterAttachRepository;
            _letterNoteRepository = letterNoteRepository;
            _mapper = mapper;
            _cache = cache;
        }
        public async Task<BaseCommandResponse> Handle(GetExportedLetterReferenceListRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            try
            {
                var validator = new LetterReferenceFilterDtoValidator();

                var validationResult = await validator.ValidateAsync(request.LetterReferenceFilterDto);

                if (validationResult.IsValid == false)
                {
                    var Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    response.Failure(errors: Errors);

                    return response;
                }


                int page = request.LetterReferenceFilterDto.Page;

                // paging
                if (page < 1)
                    page = 1;


                int take = DefaultConst.TakeCount;
                int skip = (page - 1) * take;


                if (_cache.TryGetValue(ExportedLetterReferenceList, out IEnumerable<Domain.Entity.LetterReference> letterReferences))
                {

                }
                else
                {

                    letterReferences = await _letterReferenceRepository.GetAllAsyncWithPaging(a => a.FromEmployeeId == request.LetterReferenceFilterDto.EmployeeId,
                                                                                               skip, take,
                                                                                               "Letter,FromEmployee,ToEmployee,attaches"
                                                                                               , cancellationToken);

                    _cache.Set(ExportedLetterReferenceList, letterReferences, TimeSpan.FromSeconds(DefaultConst.CashTimeOut));
                }



                //var res = _mapper.Map<List<GetLetterReferenceInfoDto>>(letterReferences);


                var data = letterReferences.Select(a => new GetLetterReferenceInfoDto
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
