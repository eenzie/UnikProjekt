using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Infrastructure.Database.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ComplexProperty(e => e.Name);
        builder.ComplexProperty(e => e.Email);
        builder.ComplexProperty(e => e.MobileNumber);
    }
}
