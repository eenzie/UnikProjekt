namespace UnikProjekt.Application.Commands.DTOs
{
    public class CreateUserAndAssignRoleRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
    }
}
