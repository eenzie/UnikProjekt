using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Infrastructure.Database.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.OwnsOne(e => e.Name);
        builder.OwnsOne(e => e.Email);
        builder.OwnsOne(e => e.MobileNumber);
        builder.OwnsOne(e => e.Address);
        builder.HasMany(e => e.UserRoles);

        builder.Property(e => e.RowVersion).IsRowVersion();
    }
}
