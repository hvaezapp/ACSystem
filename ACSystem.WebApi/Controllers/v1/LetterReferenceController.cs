using ACSystem.Application.DTOs.LetterReference;
using ACSystem.Application.Features.LetterReference.Requests.Commands;
using ACSystem.Application.Features.LetterReference.Requests.Queries;
using ACSystem.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ACSystem.Api.Controllers.v1
{

    [ApiVersion("1", Deprecated = false)]
    public class LetterReferenceController : BaseController
    {
        private readonly IMediator _mediator;

        public LetterReferenceController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<LetterReferenceController>
        [HttpGet("[action]/{page:int}")]
        public async Task<ActionResult<BaseCommandResponse>> GetAll(int page, CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(new GetLetterReferenceListRequest { Page = page }, cancellationToken);
            return Ok(response);

        }



        // GET: api/<LetterReferenceController>
        [HttpPost("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> GetExportedLetters([FromBody] LetterReferenceFilterDto dto, CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(new GetExportedLetterReferenceListRequest { LetterReferenceFilterDto = dto }, cancellationToken);
            return Ok(response);

        }


        // GET: api/<LetterReferenceController>
        [HttpPost("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> GetImportedLetters([FromBody] LetterReferenceFilterDto dto, CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(new GetImportedLetterReferenceListRequest { LetterReferenceFilterDto = dto }, cancellationToken);
            return Ok(response);

        }




        // POST api/<LetterReferenceController>
        [HttpPost("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromForm] CreateLetterReferenceDto dto, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new CreateLetterReferenceCommand { CreateLetterReferenceDto = dto }, cancellationToken);
            return Ok(response);

        }





    }
}
