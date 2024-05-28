using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace UnikProjekt.Infrastructure.Database.Converters;

public class TimeOnlyToTimeSpanConverter : ValueConverter<TimeOnly, TimeSpan>
{
    public TimeOnlyToTimeSpanConverter() : base(
        timeOnly => timeOnly.ToTimeSpan(),
        timeSpan => TimeOnly.FromTimeSpan(timeSpan))
    { }
}
