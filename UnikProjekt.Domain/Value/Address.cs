using UnikProjekt.Domain.Shared;

namespace UnikProjekt.Domain.Value;

public record Address(string Street, string StreetNumber, string PostCode, string City) : RecordWithValidation;