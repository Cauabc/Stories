using MediatR;
using Stories.API.Commands.Response;

namespace Stories.API.Commands.Requests
{
    public class CreateStoryRequest : IRequest<CreateStoryResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
    }
}
