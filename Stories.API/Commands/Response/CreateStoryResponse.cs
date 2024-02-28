namespace Stories.API.Commands.Response
{
    public class CreateStoryResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
