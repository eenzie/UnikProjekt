using Microsoft.AspNetCore.Identity;

namespace UnikProjekt.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }

    }
}
