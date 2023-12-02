using ACSystem.Application.DTOs.LetterReference;
using ACSystem.Application.DTOs.LetterType;
using ACSystem.Application.Features.LetterReference.Requests.Queries;
using ACSystem.Application.Features.LetterType.Requests.Commands;
using ACSystem.Application.Features.LetterType.Requests.Queries;
using ACSystem.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ACSystem.WebApi.Controllers.v1
{

    [ApiVersion("1", Deprecated = false)]
    public class LetterReferenceReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LetterReferenceReportController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<LetterReferenceReporyController>
        [HttpPost("[action]/{page}")]
        public async Task<ActionResult<BaseCommandResponse>> GetAll([FromBody] LetterReferenceReportFilterDto dto , int page ,  CancellationToken cancellationToken)
        {

            var cities = await _mediator.Send(new GetLetterReferenceReportListRequest() { Page = page , LetterReferenceReportFilterDto = dto }, cancellationToken);
            return Ok(cities);

        }


       
    }
}
