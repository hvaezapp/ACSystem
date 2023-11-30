using ACSystem.Application.DTOs.Employee;
using ACSystem.Application.DTOs.LetterType;
using ACSystem.Application.Features.Employee.Requests.Commands;
using ACSystem.Application.Features.Employee.Requests.Queries;
using ACSystem.Application.Features.LetterType.Requests.Commands;
using ACSystem.Application.Features.LetterType.Requests.Queries;
using ACSystem.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ACSystem.Api.Controllers.v1
{

    [ApiVersion("1", Deprecated = false)]
    public class EmployeeController : BaseController
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/<EmployeeController>
        [HttpGet("[action]/{page:int}")]
        public async Task<ActionResult<BaseCommandResponse>> GetAll(int page, CancellationToken cancellationToken)
        {
            
            var cities = await _mediator.Send(new GetEmployeeListRequest() { Page = page }, cancellationToken);
            return Ok(cities);

        }


        // POST api/<EmployeeController>
        [HttpPost("[action]")]
        public async Task<ActionResult<BaseCommandResponse>> Create([FromBody] CreateEmployeeDto dto, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new CreateEmployeeCommand { CreateEmployeeDto = dto }, cancellationToken);
            return Ok(response);

        }


    }
}
