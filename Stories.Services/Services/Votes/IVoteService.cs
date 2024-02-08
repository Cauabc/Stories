namespace Stories.Services.Services.Votes;

public interface IVoteService
{
    bool Create(Guid storyId, Guid accountId, bool upvote);
}
