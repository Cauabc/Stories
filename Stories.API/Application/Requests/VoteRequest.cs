namespace Stories.API.Application.Requests
{
    public class VoteRequest
    {
        public Guid AccountId { get; set; }
        public Guid StoryId { get; set; }
        public bool Upvote { get; set; }
    }
}
