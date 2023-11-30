using ACSystem.Infrastructure.Const;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.LetterReference.Validator
{
    public class CreateLetterReferenceDtoValidator : AbstractValidator<CreateLetterReferenceDto>
    {
        public CreateLetterReferenceDtoValidator()
        {
            RuleFor(p => p.LetterId)
              .NotNull()
              .NotEmpty()
              .WithMessage(DefaultConst.Required);


            RuleFor(p => p.FromEmployeeId)
              .NotNull()
              .NotEmpty()
              .WithMessage(DefaultConst.Required);



            RuleFor(p => p.ToEmployeeId)
             .NotNull()
             .NotEmpty()
             .WithMessage(DefaultConst.Required);



        }
    }
}
