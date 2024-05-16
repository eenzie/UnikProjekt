using Newtonsoft.Json;

namespace UnikProjekt.Application.Commands.DTOs;

public class UpdateRoleDto
{
    public Guid Id { get; set; }
    public string RoleName { get; set; }
    public record RoleDates(
        [property: JsonProperty("StartDate")]
            DateOnly StartDate,
        [property: JsonProperty("EndDate")]
            DateOnly EndDate);
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public byte[] RowVersion { get; set; }
}
