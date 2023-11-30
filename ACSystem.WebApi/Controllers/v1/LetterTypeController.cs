using ACSystem.Application.DTOs.LetterType;
using ACSystem.Application.Features.LetterType.Requests.Commands;
using ACSystem.Application.Features.LetterType.Requests.Queries;
using ACSystem.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ACSystem.Api.Controllers.v1
{

    [ApiVersion("1", Deprecated = false)]
    public class LetterTypeController : BaseController
    {
        private readonly IMediator _mediator;

        public LetterTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<LetterTypeController>
        [HttpGet("[action]/{page:int}")]
        public async Task<ActionResult<BaseCommandResponse>> GetAll(int page, CancellationToken cancellationToken)
        {
            
            var cities = await _mediator.Send(new GetLetterTypeListRequest() { Page = page }, cancellationToken);
            return Ok(cities);

        }


        // POST api/<LetterTypeController>
        [HttpPost("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] CreateLetterTypeDto dto, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new CreateLetterTypeCommand { CreateLetterTypeDto = dto }, cancellationToken);
            return Ok(response);

        }


    }
}
