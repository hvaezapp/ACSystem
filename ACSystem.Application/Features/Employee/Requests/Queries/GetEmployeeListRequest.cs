using ACSystem.Application.Responses;
using MediatR;

namespace ACSystem.Application.Features.Employee.Requests.Queries
{
    public class GetEmployeeListRequest : IRequest<BaseCommandResponse>
    {
        public int Page { get; set; }
    }
}
