using ACSystem.Application.Contracts.Persistence;
using ACSystem.Application.DTOs.Employee;
using ACSystem.Application.DTOs.Letter;
using ACSystem.Application.DTOs.LetterAttach;
using ACSystem.Application.DTOs.LetterReference;
using ACSystem.Application.Features.LetterReference.Requests.Queries;
using ACSystem.Application.Responses;
using ACSystem.Infrastructure.Const;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace ACSystem.Application.Features.LetterReference.Handlers.Queries
{
    public class GetLetterReferenceListRequestHandler : IRequestHandler<GetLetterReferenceListRequest, BaseCommandResponse>
    {
        private const string LetterReferenceList = "LetterReferenceList";

        private readonly ILetterReferenceRepository _letterReferenceRepository;
        private readonly ILetterAttachRepository _letterAttachRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetLetterReferenceListRequestHandler(ILetterReferenceRepository letterReferenceRepository,
                                                         IMapper mapper, IMemoryCache cache,
                                                         ILetterAttachRepository letterAttachRepository)
        {
            _letterReferenceRepository = letterReferenceRepository;
            _letterAttachRepository = letterAttachRepository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<BaseCommandResponse> Handle(GetLetterReferenceListRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                // paging
                if (request.Page < 1)
                    request.Page = 1;


                int take = DefaultConst.TakeCount;
                int skip = (request.Page - 1) * take;


                var letterReferences = await _letterReferenceRepository.GetAllAsyncWithPaging(null, skip, take,
                                                                    "Letter,FromEmployee,ToFromEmployee,attaches",
                                                                    cancellationToken);

                //var res = _mapper.Map<List<GetLetterReferenceInfoDto>>(letterReferences);


                var data = letterReferences.Select(a => new GetLetterReferenceInfoDto
                {
                    Attaches = a.attaches.Select(a => new GetLetterAttahchInfoDto { FileName = a.FileUrl }).ToList(),
                    FromEmployee = _mapper.Map<GetEmployeeDto>(a.FromEmployee),
                    ToEmployee = _mapper.Map<GetEmployeeDto>(a.ToEmployee),
                    letter = _mapper.Map<GetLetterDto>(a.Letter),
                    ReplyText = a.ReplyText

                }).ToList();


                var result = new GetLetterReferencesListWithPagingDto
                {
                    list = data,
                    page = request.Page,
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
