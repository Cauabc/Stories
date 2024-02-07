using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoryEntity = Stories.Infrastructure.Models.Story;

namespace Stories.Infrastructure.Data.ModelConfigs.Story;

public class StoryConfig : IEntityTypeConfiguration<StoryEntity>
{
    public void Configure(EntityTypeBuilder<StoryEntity> builder)
    {
        builder.Property(s => s.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(s => s.Description)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(s => s.Department)
            .IsRequired()
            .HasMaxLength(30);

        builder.HasMany(s => s.Votes)
            .WithOne(v => v.Story)
            .HasForeignKey(v => v.StoryId);
    }
}
