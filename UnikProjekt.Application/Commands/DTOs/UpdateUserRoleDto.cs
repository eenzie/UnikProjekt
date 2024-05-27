using Newtonsoft.Json;

namespace UnikProjekt.Application.Commands.DTOs;

public class UpdateUserRoleDto
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public record RoleDates(
        [property: JsonProperty("StartDate")]
        DateOnly StartDate,
        [property: JsonProperty("EndDate")]
        DateOnly EndDate);
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public byte[] RowVersion { get; set; }
}
