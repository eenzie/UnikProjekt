namespace UnikProjekt.Application.Commands.DTOs;

public class UpdateRoleDto
{
    public Guid Id { get; set; }
    public string RoleName { get; set; }
    public byte[] RowVersion { get; set; }
}
