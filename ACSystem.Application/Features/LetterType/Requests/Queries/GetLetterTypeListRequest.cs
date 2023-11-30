using ACSystem.Application.Responses;
using MediatR;

namespace ACSystem.Application.Features.LetterType.Requests.Queries
{
    public class GetLetterTypeListRequest : IRequest<BaseCommandResponse>
    {
        public int Page { get; set; }
    }
}
