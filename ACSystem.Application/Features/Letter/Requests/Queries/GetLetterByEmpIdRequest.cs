using ACSystem.Application.DTOs.LetterReference;
using ACSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.Features.Letter.Requests.Queries
{
    public class GetLetterByEmpIdRequest :  IRequest<BaseCommandResponse>
    {
        public LetterReferenceFilterDto LetterReferenceFilterDto { get; set; }
    }
}
