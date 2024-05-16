using Newtonsoft.Json;

namespace UnikProjekt.Application.Commands.DTOs
{
    public class CreateRoleDto
    {
        public string RoleName { get; set; }
        public record RoleDates(
            [property: JsonProperty("StartDate")]
            DateOnly StartDate,
            [property: JsonProperty("EndDate")]
            DateOnly EndDate);
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
