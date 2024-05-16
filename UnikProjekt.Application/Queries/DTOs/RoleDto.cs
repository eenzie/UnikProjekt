namespace UnikProjekt.Application.Queries.DTOs;

public class RoleDto
{
    public Guid Id { get; set; }
    public string RoleName { get; set; }
    //public List<string> UserId { get; set; }
    public byte[] RowVersion { get; set; } = [];
}
