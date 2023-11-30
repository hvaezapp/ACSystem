using ACSystem.Infrastructure.Const;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.Letter.Validator
{
    public class CreateLetterDtoValidator : AbstractValidator<CreateLetterDto>
    {
        public CreateLetterDtoValidator()
        {
            RuleFor(p => p.Title)
              .NotNull()
              .NotEmpty()
              .WithMessage(DefaultConst.Required);


            RuleFor(p => p.Description)
              .NotNull()
              .NotEmpty()
              .WithMessage(DefaultConst.Required);


            RuleFor(p => p.LetterTypeId)
              .NotNull()
              .NotEmpty()
              .WithMessage(DefaultConst.Required);



            RuleFor(p => p.EmployeeId)
              .NotNull()
              .NotEmpty()
              .WithMessage(DefaultConst.Required);







        }
    }
}
