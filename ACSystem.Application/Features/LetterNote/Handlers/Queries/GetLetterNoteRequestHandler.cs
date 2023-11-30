using ACSystem.Application.Contracts.Persistence;
using ACSystem.Application.DTOs.LetterNote;
using ACSystem.Application.DTOs.LetterType;
using ACSystem.Application.Features.LetterNote.Requests.Queries;
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

namespace ACSystem.Application.Features.LetterNote.Handlers.Queries
{
    public class GetLetterNoteRequestHandler : IRequestHandler<GetLetterNoteRequest, BaseCommandResponse>
    {
        private const string LetterNoteeListCacheKey = "LetterNoteeListCacheKey";

        private readonly ILetterNoteRepository _letterNoteRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetLetterNoteRequestHandler(ILetterNoteRepository letterNoteRepository,
            IMapper mapper, IMemoryCache cache)
        {
            _letterNoteRepository = letterNoteRepository;
            _mapper = mapper;
            _cache = cache;
        }


        public async Task<BaseCommandResponse> Handle(GetLetterNoteRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();



            try
            {
                // paging
                if (request.Page < 1)
                    request.Page = 1;


                int take = DefaultConst.TakeCount;
                int skip = (request.Page - 1) * take;




                if (_cache.TryGetValue(LetterNoteeListCacheKey, out IEnumerable<Domain.Entity.LetterNote> letterNotes))
                {

                }
                else
                {
                    // Read From Dapper

                    letterNotes = await _letterNoteRepository.GetAllWithPagingWithDapper(skip, take, cancellationToken);


                    // Read From EF
                    //letterTypes = await _letterTypeRepository.GetAllAsyncWithPaging(skip, take, cancellationToken);

                    _cache.Set(LetterNoteeListCacheKey, letterNotes, TimeSpan.FromSeconds(DefaultConst.CashTimeOut));
                }


                var letterTypeDtos = _mapper.Map<List<GetLetterNoteDto>>(letterNotes);


                var data = new GetLetterNoteListWithPagingDto
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
