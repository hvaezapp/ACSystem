using ACSystem.Infrastructure.Const;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.LetterNote.Validator
{
    public class CreateLetterNoteDtoValidator : AbstractValidator<CreateLetterNoteDto>
    {
        public CreateLetterNoteDtoValidator()
        {
            RuleFor(p => p.LetterId)
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
