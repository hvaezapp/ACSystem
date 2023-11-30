using ACSystem.Infrastructure.Const;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.LetterType.Validator
{
    public class CreateLetterTypeDtoValidator : AbstractValidator<CreateLetterTypeDto>
    {
        public CreateLetterTypeDtoValidator()
        {

            RuleFor(p => p.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage(DefaultConst.Required);


        }
    }
   
}
