using Stories.Infrastructure.Data;
using Stories.Services.DTOs;
using StoryEntity = Stories.Infrastructure.Models.Story;

namespace Stories.Services.Services.Story;

public class StoryService(ApplicationDataContext context) : IStoryService
{
    private readonly ApplicationDataContext _context = context;

    public Guid Create(string title, string description, string department)
    {
        var storyToCreate = new StoryEntity { Title = title, Description = description, Department = department };

        _context.Stories.Add(storyToCreate);

        if (_context.SaveChanges() == 0)
            return Guid.Empty;

        return storyToCreate.Id;
    }

    public IEnumerable<StoryDTO> GetAll()
    {
        return _context.Stories.Select(s => new StoryDTO { Id = s.Id, Title = s.Title, Description = s.Description, Department = s.Department, Likes = s.Votes.Count(v => v.Upvote && v.StoryId == s.Id), Dislikes = s.Votes.Count(v => v.Upvote == false && v.StoryId == s.Id) }).ToList();
    }

    public StoryDTO GetById(Guid id)
    {
        return _context.Stories.Select(s => new StoryDTO { Id = s.Id, Title = s.Title, Description = s.Description, Department = s.Department, Likes = s.Votes.Count(v => v.Upvote && v.StoryId == s.Id), Dislikes = s.Votes.Count(v => v.Upvote == false && v.StoryId == s.Id) }).FirstOrDefault(s => s.Id == id);
    }
}
