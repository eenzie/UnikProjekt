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

        //// Seed data for User
        //builder.HasData(
        //    new
        //    {
        //        Id = new Guid("1b904a62-84b1-42cf-bce3-b6f5f40f82fc"),
        //        FirstName = "John",
        //        LastName = "Doe"
        //    },
        //    new
        //    {
        //        Id = new Guid("3857c6ad-5183-4e2f-b250-65d46ed47a2c"),
        //        FirstName = "Jane",
        //        LastName = "Smith"
        //    }
        //);

        //// Seed data for EmailAddress
        //builder.OwnsOne(e => e.Email)
        //    .HasData(
        //        new
        //        {
        //            UserId = "1b904a62-84b1-42cf-bce3-b6f5f40f82fc",
        //            Value = "email1@example.com"
        //        },
        //        new
        //        {
        //            UserId = "3857c6ad-5183-4e2f-b250-65d46ed47a2c",
        //            Value = "email2@example.com"
        //        }
        //    );

        //// Seed data for MobileNumber
        //builder.OwnsOne(e => e.MobileNumber)
        //    .HasData(
        //        new
        //        {
        //            UserId = "1b904a62-84b1-42cf-bce3-b6f5f40f82fc",
        //            Value = "88888888"
        //        },
        //        new
        //        {
        //            UserId = "3857c6ad-5183-4e2f-b250-65d46ed47a2c",
        //            Value = "77777777"
        //        }
        //    );

        //builder.OwnsOne(e => e.Name);
        //builder.OwnsOne(e => e.Email);
        //builder.OwnsOne(e => e.MobileNumber);

        //builder.HasData(
        //    new
        //    {
        //        Id = Guid.NewGuid(),
        //        Email = "email1@example.com",
        //        FirstName = "John",
        //        LastName = "Doe",
        //        MobileNumber = "88888888"
        //    },
        //    new
        //    {
        //        Id = Guid.NewGuid(),
        //        Email = "email2@example.com",
        //        FirstName = "Jane",
        //        LastName = "Smith",
        //        MobileNumber = "77777777"
        //    }
        //);
    }
}
