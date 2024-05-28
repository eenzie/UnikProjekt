using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Infrastructure.Database.Converters;

namespace UnikProjekt.Infrastructure.Database.EntityConfiguration;

public class BookingItemConfiguration : IEntityTypeConfiguration<BookingItem>
{
    public void Configure(EntityTypeBuilder<BookingItem> builder)
    {
        builder.Property(e => e.Price).HasPrecision(16, 2);
        builder.Property(e => e.Deposit).HasPrecision(16, 2);

        //Instans af Converter klasse til at konverterer TimeOnly properties
        var timeOnlyToTimeSpanConverter = new TimeOnlyToTimeSpanConverter();

        builder.Property(e => e.IntervalStart)
            .HasConversion(timeOnlyToTimeSpanConverter)
            .IsRequired();

        builder.Property(e => e.IntervalEnd)
            .HasConversion(timeOnlyToTimeSpanConverter)
            .IsRequired();

        builder.Property(e => e.BookingTimeInMinutes).IsRequired();
        builder.Property(e => e.RowVersion).IsRowVersion();
    }
}
