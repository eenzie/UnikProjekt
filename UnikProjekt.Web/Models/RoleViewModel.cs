using System.ComponentModel.DataAnnotations;
using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.Models
{
    public class RoleViewModel
    {
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Rolle title")]
        public string RoleName { get; set; }

        [Display(Name = "Bruger rolle")]
        public List<UserRoleDto> UserRoles { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
