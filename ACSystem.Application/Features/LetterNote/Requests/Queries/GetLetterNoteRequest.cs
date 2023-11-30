using ACSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.Features.LetterNote.Requests.Queries
{
    public class GetLetterNoteRequest : IRequest<BaseCommandResponse>
    {
        public int Page { get; set; }
    }
}
