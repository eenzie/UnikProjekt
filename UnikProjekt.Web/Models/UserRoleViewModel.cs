using System.ComponentModel.DataAnnotations;

namespace UnikProjekt.Web.Models
{
    public class UserRoleViewModel
    {
        [Display(Name = "Bruger id")]
        public Guid UserId { get; set; }

        [Display(Name = "Brugernavn")]
        public string UserName { get; set; }

        [Display(Name = "Rollenavn")]
        public string RoleName { get; set; }

        [Display(Name = "Start dato")]
        public DateOnly StartDate { get; set; }

        [Display(Name = "Slut dato")]
        public DateOnly EndDate { get; set; }

    }
}
