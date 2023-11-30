using ACSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.Features.LetterReference.Requests.Queries
{
    public class GetLetterReferenceListRequest : IRequest<BaseCommandResponse>
    {
        public int Page { get; set; }
    }
}
