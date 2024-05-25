namespace UnikProjekt.Web.Models.DTOs
{
    public class CreateUserRoleDto
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
