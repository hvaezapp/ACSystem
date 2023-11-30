using ACSystem.Application.Contracts.Persistence;
using ACSystem.Application.DTOs.Employee;
using ACSystem.Application.DTOs.Letter;
using ACSystem.Application.DTOs.LetterNote;
using ACSystem.Application.DTOs.LetterReference.Validator;
using ACSystem.Application.DTOs.LetterType;
using ACSystem.Application.Features.Letter.Requests.Queries;
using ACSystem.Application.Responses;
using ACSystem.Infrastructure.Const;
using ACSystem.Infrastructure.Utilities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.Features.Letter.Handlers.Queries
{
    public class GetLetterByEmpIdRequestHandler : IRequestHandler<GetLetterByEmpIdRequest, BaseCommandResponse>
    {
        private const string LetterByEmpIdListCacheKey = "LetterByEmpIdListCacheKey";

        private readonly ILetterRepository _letterRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetLetterByEmpIdRequestHandler(ILetterRepository letterRepository,
            IMapper mapper, IMemoryCache cache)
        {
            _letterRepository = letterRepository;
            _mapper = mapper;
            _cache = cache;
        }


        public async Task<BaseCommandResponse> Handle(GetLetterByEmpIdRequest request, CancellationToken cancellationToken)
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


                if (_cache.TryGetValue(LetterByEmpIdListCacheKey, out IEnumerable<Domain.Entity.Letter> letters))
                {

                }
                else
                {


                    letters = await _letterRepository.GetAllAsyncWithPaging(a=>a.EmployeeId == request.LetterReferenceFilterDto.EmployeeId , skip, take, "Employee,LetterType,LetterNotes", cancellationToken);

                    _cache.Set(LetterByEmpIdListCacheKey, letters, TimeSpan.FromSeconds(DefaultConst.CashTimeOut));
                }

                //var letterDtos = _mapper.Map<List<GetLetterInfoWithLetterNoteDto>>(letters);

                var res = letters.Select(a => new GetLetterInfoWithLetterNoteDto
                {
                    LetterNotes = _mapper.Map<List<GetLetterNoteDto>>(a.LetterNotes),
                    Title = a.Title,
                    Description = a.Description,
                    Code = a.Code,
                    Status = a.Status,
                    LetterType = _mapper.Map<GetLetterTypeDto>(a.LetterType),
                    Employee = _mapper.Map<GetEmployeeDto>(a.Employee),
                    StatusText = a.Status.ToDisplay(),
                    LetterTypeId = a.LetterTypeId,
                    EmployeeId = a.EmployeeId,

                }).ToList();


                var data = new GetLetterListWithPagingDto
                {
                    list = res,
                    page = page,
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
