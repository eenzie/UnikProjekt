using Newtonsoft.Json;

namespace UnikProjekt.Application.Queries.DTOs;

public class UserRoleDto
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
}
