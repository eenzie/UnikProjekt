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
    public byte[] RowVersion { get; set; }
}
