using MediatR;
using Stories.Services.Services.Story;

namespace Stories.API.Commands
{
    public class UpdateStoryCommandHandler(IStoryService service) : IRequestHandler<UpdateStoryCommand, bool?>
    {
        private readonly IStoryService _service = service;

        public async Task<bool?> Handle(UpdateStoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.Update(request.Id, request.Title, request.Description, request.Department);

            return result;
        }
    }
}
