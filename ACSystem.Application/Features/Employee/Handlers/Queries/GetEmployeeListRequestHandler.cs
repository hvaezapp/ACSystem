using ACSystem.Application.Contracts.Persistence;
using ACSystem.Application.DTOs.Employee;
using ACSystem.Application.DTOs.LetterType;
using ACSystem.Application.Features.Employee.Requests.Queries;
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

namespace ACSystem.Application.Features.Employee.Handlers.Queries
{
    public class GetEmployeeListRequestHandler : IRequestHandler<GetEmployeeListRequest, BaseCommandResponse>
    {
        private const string EmployeeListCacheKey = "EmployeeList";

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetEmployeeListRequestHandler(IEmployeeRepository employeeRepository,
            IMapper mapper, IMemoryCache cache)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _cache = cache;
        }



        public async Task<BaseCommandResponse> Handle(GetEmployeeListRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

           

            try
            {
                // paging
                if (request.Page < 1)
                    request.Page = 1;


                int take = DefaultConst.TakeCount;
                int skip = (request.Page - 1) * take;




                if (_cache.TryGetValue(EmployeeListCacheKey, out IEnumerable<Domain.Entity.Employee> employees))
                {

                }
                else
                {
                   

                    employees = await _employeeRepository.GetAllAsyncWithPaging(skip, take, cancellationToken);

                    _cache.Set(EmployeeListCacheKey, employees, TimeSpan.FromSeconds(DefaultConst.CashTimeOut));
                }


                var employeeDtos = _mapper.Map<List<GetEmployeeDto>>(employees);


                var data = new GetEmployeeListWithPagingDto
                {
                    list = employeeDtos,
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
