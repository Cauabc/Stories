using MediatR;
using Stories.API.Application.ViewModels;

namespace Stories.API.Queries
{
    public class GetStoryByIdQuery : IRequest<StoryViewModel>
    {
        public Guid Id { get; set; }
    }
}
