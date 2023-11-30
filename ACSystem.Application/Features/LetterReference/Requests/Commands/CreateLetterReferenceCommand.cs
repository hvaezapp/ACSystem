using ACSystem.Application.DTOs.LetterReference;
using ACSystem.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.Features.LetterReference.Requests.Commands
{
    public class CreateLetterReferenceCommand : IRequest<BaseCommandResponse>
    {
        public CreateLetterReferenceDto CreateLetterReferenceDto { get; set; }


    }
}
