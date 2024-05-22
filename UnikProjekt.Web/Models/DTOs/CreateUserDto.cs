namespace UnikProjekt.Web.Models.DTOs
{
    public class CreateUserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserAddress { get; set; }
    }
}
