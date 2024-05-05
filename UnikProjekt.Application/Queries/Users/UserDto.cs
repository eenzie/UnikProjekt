namespace UnikProjekt.Application.Queries.Users;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public byte[] RowVersion { get; set; } = [];
}
