namespace Stories.Infrastructure.Models;

public class Account
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Email { get; set; }
}
