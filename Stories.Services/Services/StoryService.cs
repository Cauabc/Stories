using Stories.Infrastructure.Data;
using Stories.Services.DTOs;

namespace Stories.Services.Services;

public class StoryService(ApplicationDataContext context) : IStoryService
{
    private readonly ApplicationDataContext _context = context;

    public IEnumerable<StoryDTO> GetAll()
    {
        return _context.Stories.Select(s => new StoryDTO { Id = s.Id, Title = s.Title, Description = s.Description, Department = s.Department, Likes = s.Votes.Where(v => v.Upvote == true && v.StoryId == s.Id).Count(), Dislikes = s.Votes.Where(v => v.Upvote == false && v.StoryId == s.Id).Count() }).ToList();
    }
}
