using Microsoft.EntityFrameworkCore;
using Stories.Infrastructure.Data;
using Stories.Services.DTOs;
using StoryEntity = Stories.Infrastructure.Models.Story;
using VoteEntity = Stories.Infrastructure.Models.Vote;

namespace Stories.Services.Services.Story;

public class StoryService(ApplicationDataContext context) : IStoryService
{
    private readonly ApplicationDataContext _context = context;

    public async Task<Guid> Create(string title, string description, string department)
    {
        var storyToCreate = new StoryEntity { Title = title, Description = description, Department = department };

        _context.Stories.Add(storyToCreate);

        await _context.SaveChangesAsync();

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

    public async Task<IEnumerable<StoryDTO>> GetAll()
    {
        var result = await _context.Stories.Select(s => new StoryDTO
        {
            Id = s.Id,
            Title = s.Title,
            Description = s.Description,
            Department = s.Department,
            Likes = s.Votes.Count(v => v.Upvote),
            Dislikes = s.Votes.Count(v => v.Upvote == false)
        })
        .ToListAsync();

        return result;
    }

    public async Task<StoryDTO> GetById(Guid id)
    {
        return await _context.Stories.Select(s => new StoryDTO { Id = s.Id, Title = s.Title, Description = s.Description, Department = s.Department, Likes = s.Votes.Count(v => v.Upvote), Dislikes = s.Votes.Count(v => v.Upvote == false) }).FirstOrDefaultAsync(s => s.Id == id);
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
