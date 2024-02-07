using Stories.Infrastructure.Data;
using Stories.Services.DTOs;

namespace Stories.Services.Services.Story;

public class StoryService(ApplicationDataContext context) : IStoryService
{
    private readonly ApplicationDataContext _context = context;

    public IEnumerable<StoryDTO> GetAll()
    {
        return _context.Stories.Select(s => new StoryDTO { Id = s.Id, Title = s.Title, Description = s.Description, Department = s.Department, Likes = s.Votes.Count(v => v.Upvote && v.StoryId == s.Id), Dislikes = s.Votes.Count(v => v.Upvote == false && v.StoryId == s.Id) }).ToList();
    }

    public StoryDTO GetById(Guid id)
    {
        return _context.Stories.Select(s => new StoryDTO { Id = s.Id, Title = s.Title, Description = s.Description, Department = s.Department, Likes = s.Votes.Count(v => v.Upvote && v.StoryId == s.Id), Dislikes = s.Votes.Count(v => v.Upvote == false && v.StoryId == s.Id) }).FirstOrDefault(s => s.Id == id);
    }
}
