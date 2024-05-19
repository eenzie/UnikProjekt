namespace UnikProjekt.Web.Models.DTOs
{
    public class RegisterUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        //public UserType UserType { get; set; }
        public List<string> UserTypes { get; set; }
    }
}
