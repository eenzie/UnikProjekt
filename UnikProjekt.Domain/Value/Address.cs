namespace UnikProjekt.Domain.Value;

public record Address(string Street, string StreetNumber, string PostCode, string City);

//TODO: DAWA validering kræver nok at vi har noget logik, så skal nok ikke være en record.
//Den skal valideres i constructoren via DAWA
//Vi må ikke lave kaldet i domain klassen. Vi laver et interface IAddressService
//I infrastrukture implementere vi AddressService and opretter HTTPClient dernede 
