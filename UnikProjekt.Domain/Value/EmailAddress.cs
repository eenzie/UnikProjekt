using UnikProjekt.Domain.Shared;

namespace UnikProjekt.Domain.Value;

public record EmailAddress(string Value) : RecordWithValidation
{
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value)) throw new ArgumentException("Mail-adressen må ikke være tom");

        if (!Value.Contains('@')) throw new ArgumentException("Mail-adressen er ikke valid");
    }
}
