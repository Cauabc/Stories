using Microsoft.EntityFrameworkCore;
using Stories.Infrastructure.Data.ModelConfigs.Story;
using Stories.Infrastructure.Data.ModelConfigs.Vote;
using Stories.Infrastructure.Models;

namespace Stories.Infrastructure.Data;

public class ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfig());
        modelBuilder.ApplyConfiguration(new StoryConfig());
        modelBuilder.ApplyConfiguration(new VoteConfig());
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Story> Stories { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Vote> Votes { get; set; }
}
