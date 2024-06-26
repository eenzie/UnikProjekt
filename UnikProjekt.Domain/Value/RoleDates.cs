﻿using UnikProjekt.Domain.Shared;

namespace UnikProjekt.Domain.Value;

public record RoleDates(DateOnly StartDate, DateOnly EndDate) : RecordWithValidation
{
    public int DurationInDays => EndDate.DayNumber - StartDate.DayNumber;

    protected override void Validate()
    {
        if (StartDate > EndDate) throw new ArgumentException("Start date must be before end date");
    }
}
