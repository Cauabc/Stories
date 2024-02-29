using MediatR;

namespace Stories.API.Commands
{
    public class CreateStoryCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
    }
}
