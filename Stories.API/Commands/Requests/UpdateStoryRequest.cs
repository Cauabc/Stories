using MediatR;

namespace Stories.API.Commands.Requests
{
    public class UpdateStoryRequest : IRequest<bool?>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
    }
}
