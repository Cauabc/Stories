using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteEntity = Stories.Infrastructure.Models.Vote;
namespace Stories.Infrastructure.Data.ModelConfigs.Vote
{
    public class VoteConfig : IEntityTypeConfiguration<VoteEntity>
    {
        public void Configure(EntityTypeBuilder<VoteEntity> builder)
        {
            builder.Property(v => v.Upvote)
                .IsRequired();

            builder.HasOne(v => v.Story)
                .WithMany(s => s.Votes)
                .HasForeignKey(v => v.StoryId);

            builder.HasOne(v => v.Account)
                .WithMany(a => a.Votes)
                .HasForeignKey(v => v.AccountId);
        }
    }
}
