using MediatR;
using Stories.API.Queries.Responses;

namespace Stories.API.Queries.Requests;

public class FindStoryByIdRequest : IRequest<FindStoryByIdResponse>
{
    public Guid Id { get; set; }
}
