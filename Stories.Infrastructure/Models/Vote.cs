namespace Stories.Infrastructure.Models;

public class Vote
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid StoryId { get; set; }
    public Guid AccountId { get; set; }
    public bool Upvote { get; set; }
}
