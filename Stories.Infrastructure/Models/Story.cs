namespace Stories.Infrastructure.Models;

public class Story
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Description { get; set; }
    public string Department { get; set; }
    public List<Vote> Votes { get; set; }
}
