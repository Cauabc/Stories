using MediatR;
using Stories.API.Commands.Requests;
using Stories.API.Commands.Response;
using Stories.Infrastructure.Models;
using Stories.Services.Services.Story;

namespace Stories.API.Handlers
{
    public class CreateStoryHandler(IStoryService service) : IRequestHandler<CreateStoryRequest, CreateStoryResponse>
    {
        private readonly IStoryService _service = service;

        public async Task<CreateStoryResponse> Handle(CreateStoryRequest request, CancellationToken cancellationToken)
        {
            var story = new Story
            {
                Title = request.Title,
                Description = request.Description,
                Department = request.Department
            };

            await _service.Create(request.Title, request.Description, request.Department);

            var result = new CreateStoryResponse
            {
                Id = story.Id,
                Title = story.Title,
                Description = story.Description,
                Department = story.Department,
                CreatedAt = DateTime.Now,
            };

            return result;
            
        }
    }
}
