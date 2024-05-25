namespace UnikProjekt.Web.Models.DTOs
{
    public class EditRoleDto
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
