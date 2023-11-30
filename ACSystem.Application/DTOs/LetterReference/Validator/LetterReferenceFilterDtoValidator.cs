using ACSystem.Infrastructure.Const;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.LetterReference.Validator
{
    public class LetterReferenceFilterDtoValidator : AbstractValidator<LetterReferenceFilterDto>
    {
        public LetterReferenceFilterDtoValidator()
        {
            RuleFor(p => p.EmployeeId)
             .NotNull()
             .NotEmpty()
             .WithMessage(DefaultConst.Required);

        }
    }
}
