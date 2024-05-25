using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.Models
{
    public class RoleViewModel
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }

        public List<UserRoleDto> UserRoles { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
