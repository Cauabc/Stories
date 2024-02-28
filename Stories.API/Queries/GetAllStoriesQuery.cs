using MediatR;
using Stories.API.Application.ViewModels;

namespace Stories.API.Queries
{
    public class GetAllStoriesQuery : IRequest<IEnumerable<StoryViewModel>>
    {
    }
}
