using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Infrastructure.Database.EntityConfiguration;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasOne(e => e.User);
        builder.HasMany(e => e.Items);
        builder.Property(e => e.SubTotal).HasPrecision(16, 2).IsRequired();
        builder.Property(e => e.TotalPrice).HasPrecision(16, 2).IsRequired();

        builder.Property(e => e.RowVersion).IsRowVersion();
    }
}
