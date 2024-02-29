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

    public async Task<bool> Delete(Guid id)
    {
        var itemToDelete = await _context.Stories.FirstOrDefaultAsync(x => x.Id == id);

        if (itemToDelete == null)
            return false;

        _context.Stories.Remove(itemToDelete);
        await _context.SaveChangesAsync();

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

    public async Task<bool?> Update(Guid id, string title, string description, string department)
    {
        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(department))
            return false;
         
        var itemToUpdate = await _context.Stories.FirstOrDefaultAsync(x => x.Id == id);

        if (itemToUpdate == null)
            return null;

        itemToUpdate.Title = title;
        itemToUpdate.Description = description;
        itemToUpdate.Department = department;

        _context.Stories.Update(itemToUpdate);
        await _context.SaveChangesAsync();

        return true;
    }
    public async Task PostVote(Guid storyId, Guid accountId, bool upvote)
    {
        _context.Votes.Add(new VoteEntity { StoryId = storyId, AccountId = accountId, Upvote = upvote });
        await _context.SaveChangesAsync();
    }
}
