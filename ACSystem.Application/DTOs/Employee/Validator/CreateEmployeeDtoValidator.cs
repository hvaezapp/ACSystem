using ACSystem.Infrastructure.Const;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.Employee.Validator
{
    public class CreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeDtoValidator()
        {
            RuleFor(p => p.FirstName)
              .NotNull()
              .NotEmpty()
              .WithMessage(DefaultConst.Required);


            RuleFor(p => p.LastName)
              .NotNull()
              .NotEmpty()
              .WithMessage(DefaultConst.Required);


            RuleFor(p => p.Email)
              .NotNull()
              .NotEmpty()
              .WithMessage(DefaultConst.Required)
              .EmailAddress()
              .WithMessage(DefaultConst.EmailInvalid);


            RuleFor(p => p.IdentityCode)
              .NotNull()
              .NotEmpty()
              .WithMessage(DefaultConst.Required)
              .Length(min:8,max:8)
              .WithMessage(DefaultConst.LengthExceed);
        }
    }
}
