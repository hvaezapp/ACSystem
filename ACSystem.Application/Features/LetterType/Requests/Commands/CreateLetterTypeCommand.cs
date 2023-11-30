using ACSystem.Application.DTOs.LetterType;
using ACSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.Features.LetterType.Requests.Commands
{
    public class CreateLetterTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateLetterTypeDto CreateLetterTypeDto { get; set; }
    }
}
