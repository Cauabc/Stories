using MediatR;
using Stories.API.Commands.Requests;
using Stories.Services.Services.Story;

namespace Stories.API.Handlers
{
    public class UpdateStoryHandler(IStoryService service) : IRequestHandler<UpdateStoryRequest, bool?>
    {
        private readonly IStoryService _service = service;

        public async Task<bool?> Handle(UpdateStoryRequest request, CancellationToken cancellationToken)
        {
            var isSucceded = await _service.Update(request.Id, request.Title, request.Description, request.Department);

            return isSucceded;
        }
    }
}
