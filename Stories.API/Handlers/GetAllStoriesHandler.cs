using MediatR;
using Stories.API.Application.ViewModels;
using Stories.API.Queries;
using Stories.Services.Services.Story;

namespace Stories.API.Handlers
{
    public class GetAllStoriesHandler(IStoryService service) : IRequestHandler<GetAllStoriesQuery, IEnumerable<StoryViewModel>>
    {
        private readonly IStoryService _service = service;
        public async Task<IEnumerable<StoryViewModel>> Handle(GetAllStoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetAll();

            return result.Select(s => new StoryViewModel { 
                Id = s.Id,
                Title = s.Title,
                Department = s.Department,
                Description = s.Description,
                Likes = s.Likes,
                Dislikes = s.Dislikes
            });
        }
    }
}
