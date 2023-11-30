using ACSystem.Application.DTOs.LetterReference;
using ACSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.Features.LetterReference.Requests.Queries
{
    public class GetExportedLetterReferenceListRequest : IRequest<BaseCommandResponse>
    {
        public LetterReferenceFilterDto LetterReferenceFilterDto { get; set; }
    }
}
