using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoryEntity = Stories.Infrastructure.Models.Story;
using VoteEntity = Stories.Infrastructure.Models.Vote;
using AccountEntity = Stories.Infrastructure.Models.Account;

namespace Stories.Infrastructure.Data.ModelConfigs.Vote
{
    public class VoteConfig : IEntityTypeConfiguration<VoteEntity>
    {
        public void Configure(EntityTypeBuilder<VoteEntity> builder)
        {
            builder.Property(v => v.Upvote)
                .IsRequired();

            builder.HasOne<StoryEntity>()
                .WithMany(s => s.Votes)
                .HasForeignKey(v => v.StoryId);

            builder.HasOne<AccountEntity>()
                .WithMany()
                .HasForeignKey(v => v.AccountId);
        }
    }
}
