namespace UnikProjekt.Application.Commands.DTOs;

public class UpdateUserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public byte[] RowVersion { get; set; } = [];
}
