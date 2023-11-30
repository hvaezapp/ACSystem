using ACSystem.Application.DTOs.LetterNote;
using ACSystem.Application.DTOs.LetterType;
using ACSystem.Application.Features.LetterNote.Requests.Commands;
using ACSystem.Application.Features.LetterNote.Requests.Queries;
using ACSystem.Application.Features.LetterType.Requests.Commands;
using ACSystem.Application.Features.LetterType.Requests.Queries;
using ACSystem.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ACSystem.Api.Controllers.v1
{

    [ApiVersion("1", Deprecated = false)]
    public class LetterNoteController : BaseController
    {
        private readonly IMediator _mediator;

        public LetterNoteController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<LetterNoteController>
        [HttpGet("[action]/{page:int}")]
        public async Task<ActionResult<BaseCommandResponse>> GetAll(int page, CancellationToken cancellationToken)
        {
            
            var cities = await _mediator.Send(new GetLetterNoteRequest { Page = page }, cancellationToken);
            return Ok(cities);

        }


        // POST api/<LetterNoteController>
        [HttpPost("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] CreateLetterNoteDto dto, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new CreateLetterNoteCommand { CreateLetterNoteDto = dto }, cancellationToken);
            return Ok(response);

        }


    }
}
