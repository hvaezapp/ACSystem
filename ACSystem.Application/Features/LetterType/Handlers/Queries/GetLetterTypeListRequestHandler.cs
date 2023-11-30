using ACSystem.Application.Contracts.Persistence;
using ACSystem.Application.DTOs.LetterType;
using ACSystem.Application.Features.LetterType.Requests.Queries;
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

namespace ACSystem.Application.Features.LetterType.Handlers.Queries
{
    public class GetLetterTypeListRequestHandler : IRequestHandler<GetLetterTypeListRequest, BaseCommandResponse>
    {
        private const string LetterTypeListCacheKey = "LetterType";

        private readonly ILetterTypeRepository _letterTypeRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetLetterTypeListRequestHandler(ILetterTypeRepository letterTypeRepository,
            IMapper mapper, IMemoryCache cache)
        {
            _letterTypeRepository = letterTypeRepository;
            _mapper = mapper;
            _cache = cache;
        }



        public async Task<BaseCommandResponse> Handle(GetLetterTypeListRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();


            try
            {

                // paging
                if (request.Page < 1)
                    request.Page = 1;


                int take = DefaultConst.TakeCount;
                int skip = (request.Page - 1) * take;




                if (_cache.TryGetValue(LetterTypeListCacheKey, out IEnumerable<Domain.Entity.LetterType> letterTypes))
                {

                }
                else
                {
                    // Read From Dapper

                     letterTypes = await _letterTypeRepository.GetAllWithPagingWithDapper(skip, take, cancellationToken);


                    // Read From EF
                    //letterTypes = await _letterTypeRepository.GetAllAsyncWithPaging(skip, take, cancellationToken);

                    _cache.Set(LetterTypeListCacheKey, letterTypes, TimeSpan.FromSeconds(DefaultConst.CashTimeOut));
                }


                var letterTypeDtos = _mapper.Map<List<GetLetterTypeDto>>(letterTypes);


                var data = new GetLetterTypeListWithPagingDto
                {
                    list = letterTypeDtos,
                    page = request.Page,
                };

                response.Success(data: data);


            }
            catch (Exception)
            {
                //response.Failure(message: ex.Message);
                throw;
            }


            return response; 
        }
    }
}
