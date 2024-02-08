using Stories.Infrastructure.Data;
using VoteEntity = Stories.Infrastructure.Models.Vote;

namespace Stories.Services.Services.Votes;

public class VoteService(ApplicationDataContext context) : IVoteService
{
    private readonly ApplicationDataContext _context = context;
    public bool Create(Guid storyId, Guid accountId, bool upvote)
    {
        _context.Votes.Add(new VoteEntity { StoryId = storyId, AccountId = accountId, Upvote = upvote });

        if (_context.SaveChanges() == 0)
            return false;

        return true;
    }
}
