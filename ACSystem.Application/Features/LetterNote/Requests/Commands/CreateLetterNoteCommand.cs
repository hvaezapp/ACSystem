using ACSystem.Application.DTOs.LetterNote;
using ACSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.Features.LetterNote.Requests.Commands
{
    public class CreateLetterNoteCommand : IRequest<BaseCommandResponse>
    {
        public CreateLetterNoteDto CreateLetterNoteDto { get; set; }
    }
}
