namespace Stories.Infrastructure.Models;

public class Story
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Department { get; set; }
}
