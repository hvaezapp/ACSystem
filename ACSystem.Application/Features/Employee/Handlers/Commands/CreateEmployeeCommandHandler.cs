using ACSystem.Application.Contracts.Persistence;
using ACSystem.Application.DTOs.Employee;
using ACSystem.Application.DTOs.Employee.Validator;
using ACSystem.Application.DTOs.LetterType;
using ACSystem.Application.DTOs.LetterType.Validator;
using ACSystem.Application.Features.Employee.Requests.Commands;
using ACSystem.Application.Features.LetterType.Requests.Commands;
using ACSystem.Application.Responses;
using ACSystem.Domain.Entity;
using ACSystem.Infrastructure.Const;
using ACSystem.Infrastructure.Exceptions;
using AutoMapper;
using FluentValidation.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ACSystem.Application.Features.Employee.Handlers.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BaseCommandResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }




        public async Task<BaseCommandResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

           

            try
            {
                var validator = new CreateEmployeeDtoValidator();

                var validationResult = await validator.ValidateAsync(request.CreateEmployeeDto);

                if (validationResult.IsValid == false)
                {
                    var Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    response.Failure(errors: Errors);
                }
                else
                {
                    if (await ExistByEmail(request.CreateEmployeeDto.Email, cancellationToken))
                        //response.Failure(message: DefaultConst.EmailExist);
                        throw new AppException(DefaultConst.EmailExist);
                    else if (await ExistByIdCode(request.CreateEmployeeDto.Email, cancellationToken))
                        throw new AppException(DefaultConst.IdCodeExist); 
                    else
                    {
                        var employee = _mapper.Map<Domain.Entity.Employee>(request.CreateEmployeeDto);
                        employee = await _employeeRepository.Create(employee, cancellationToken);
                        await _employeeRepository.SaveChanges(cancellationToken);

                        response.Success(data: _mapper.Map<GetEmployeeDto>(employee));
                    }


                }
            }
            catch (Exception)
            {
                //response.Failure(message: ex.Message.ToString());
                throw;
            }

            return response;
        }


        private async Task<bool> ExistByEmail(string email , CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetSingleAsync(a => a.Email.Trim().Equals(email), cancellationToken) != null;
            
        }


        private async Task<bool> ExistByIdCode(string idCode, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetSingleAsync(a => a.IdentityCode.Trim().Equals(idCode), cancellationToken) != null;

        }
    }
}
