using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Infrastructure.Database.EntityConfiguration;

public class BookingLineConfiguration : IEntityTypeConfiguration<BookingLine>
{
    public void Configure(EntityTypeBuilder<BookingLine> builder)
    {
        builder.HasOne(e => e.BookingItem);
        builder.Property(e => e.ItemPrice).HasPrecision(16, 2).IsRequired();
        builder.Property(e => e.RowVersion).IsRowVersion();
    }
}
