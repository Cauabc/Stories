using MediatR;

namespace Stories.API.Commands
{
    public class DeleteStoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
