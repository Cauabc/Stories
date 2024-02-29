using MediatR;
using Stories.API.Commands.Response;

namespace Stories.API.Commands.Requests
{
    public class DeleteStoryByIdRequest : IRequest<DeleteStoryByIdResponse>
    {
        public Guid Id { get; set; }
    }
}
