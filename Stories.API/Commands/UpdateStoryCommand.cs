using MediatR;

namespace Stories.API.Commands
{
    public class UpdateStoryCommand : IRequest<bool?>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
    }
}
