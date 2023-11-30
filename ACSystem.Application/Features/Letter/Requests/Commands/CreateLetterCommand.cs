using ACSystem.Application.DTOs.Employee;
using ACSystem.Application.DTOs.Letter;
using ACSystem.Application.DTOs.LetterType;
using ACSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.Features.Letter.Requests.Commands
{
    public class CreateLetterCommand : IRequest<BaseCommandResponse>
    {
        public CreateLetterDto CreateLetterDto { get; set; }
    }
}
