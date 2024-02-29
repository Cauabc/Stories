using MediatR;
using Stories.API.Application.ViewModels;
using Stories.Services.Services.Story;

namespace Stories.API.Queries
{
    public class GetStoryByIdQueryHandler(IStoryService service) : IRequestHandler<GetStoryByIdQuery, StoryViewModel>
    {
        private readonly IStoryService _service = service;

        public async Task<StoryViewModel> Handle(GetStoryByIdQuery request, CancellationToken cancellationToken)
        {
            var story = await _service.GetById(request.Id);

            if (story == null)
                return null;

            var result = new StoryViewModel
            {
                Id = story.Id,
                Title = story.Title,
                Description = story.Description,
                Department = story.Department,
                Likes = story.Likes,
                Dislikes = story.Dislikes
            };

            return result;
        }
    }
}
