using Newtonsoft.Json;

namespace UnikProjekt.Application.Commands.DTOs;

public class UpdateUserDto
{
    public Guid Id { get; set; }
    public record Name(
            [property: JsonProperty("FirstName")]
            string FirstName,
            [property: JsonProperty("LastName")]
            string LastName);
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public record Address(
           [property: JsonProperty("Street")]
            string Street,
           [property: JsonProperty("StreetNumber")]
            string StreetNumber,
           [property: JsonProperty("PostCode")]
            string PostCode,
           [property: JsonProperty("City")]
            string City);
    public string Street { get; set; }
    public string StreetNumber { get; set; }
    public string PostCode { get; set; }
    public string City { get; set; }
    public byte[] RowVersion { get; set; }
}
