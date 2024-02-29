using MediatR;
using Stories.Services.Services.Story;

namespace Stories.API.Commands
{
    public class DeleteStoryCommandHandler(IStoryService service) : IRequestHandler<DeleteStoryCommand, bool>
    {
        private readonly IStoryService _service = service;

        public async Task<bool> Handle(DeleteStoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.Delete(request.Id);

            return result;
        }
    }
}
