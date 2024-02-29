using MediatR;
using Stories.Services.Services.Story;

namespace Stories.API.Commands
{
    public class CreateStoryCommandHandler(IStoryService service) : IRequestHandler<CreateStoryCommand, Guid>
    {
        private readonly IStoryService _service = service;
        public async Task<Guid> Handle(CreateStoryCommand request, CancellationToken cancellationToken)
        {
            return await _service.Create(request.Title, request.Description, request.Department);
        }
    }
}
