using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AccountEntity = Stories.Infrastructure.Models.Account;

namespace Stories.Infrastructure.Data.ModelConfigs.Story;

public class AccountConfig : IEntityTypeConfiguration<AccountEntity>
{
    public void Configure(EntityTypeBuilder<AccountEntity> builder)
    {
        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasMany(a => a.Votes)
            .WithOne(v => v.Account)
            .HasForeignKey(v => v.AccountId);
    }
}
