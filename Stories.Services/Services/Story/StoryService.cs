using Stories.Infrastructure.Data;
using Stories.Services.DTOs;
using StoryEntity = Stories.Infrastructure.Models.Story;
using VoteEntity = Stories.Infrastructure.Models.Vote;

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

    public bool Delete(Guid id)
    {
        var itemToDelete = _context.Stories.FirstOrDefault(x => x.Id == id);

        if (itemToDelete == null)
            return false;

        _context.Stories.Remove(itemToDelete);
        _context.SaveChanges();

        return true;
    }

    public IEnumerable<StoryDTO> GetAll()
    {
        return _context.Stories.Select(s => new StoryDTO { Id = s.Id, Title = s.Title, Description = s.Description, Department = s.Department, Likes = s.Votes.Count(v => v.Upvote), Dislikes = s.Votes.Count(v => v.Upvote == false) }).ToList();
    }

    public StoryDTO GetById(Guid id)
    {
        return _context.Stories.Select(s => new StoryDTO { Id = s.Id, Title = s.Title, Description = s.Description, Department = s.Department, Likes = s.Votes.Count(v => v.Upvote), Dislikes = s.Votes.Count(v => v.Upvote == false) }).FirstOrDefault(s => s.Id == id);
    }

    public bool Update(Guid id, string title, string description, string department)
    {
        var itemToUpdate = _context.Stories.FirstOrDefault(x => x.Id == id);

        if (itemToUpdate == null)
            return false;

        itemToUpdate.Title = title;
        itemToUpdate.Description = description;
        itemToUpdate.Department = department;

        _context.Stories.Update(itemToUpdate);
        _context.SaveChanges();

        return true;
    }
    public void PostVote(Guid storyId, Guid accountId, bool upvote)
    {
        _context.Votes.Add(new VoteEntity { StoryId = storyId, AccountId = accountId, Upvote = upvote });
        _context.SaveChanges();
    }
}
