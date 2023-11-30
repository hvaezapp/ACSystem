using ACSystem.Application.Responses;
using MediatR;

namespace ACSystem.Application.Features.Letter.Requests.Queries
{
    public class GetLetterListRequest : IRequest<BaseCommandResponse>
    {
        public int Page { get; set; }
    }
}
