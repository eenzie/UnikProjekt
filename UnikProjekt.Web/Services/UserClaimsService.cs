using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using UnikProjekt.Web.Models;

namespace UnikProjekt.Web.Services
{
    public class UserClaimsService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserClaimsService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task AssignClaimsAsync(ApplicationUser user, string role)
        {

            switch (role)
            {
                case "Beboer":
                case "Menig":
                    await _userManager.AddClaimAsync(user, new Claim("Permission", "Reader"));
                    break;
                case "Sekretær":
                case "Kasser":
                    await _userManager.AddClaimAsync(user, new Claim("Permission", "User"));
                    break;
                case "NæstFormand":
                case "Formand":
                    await _userManager.AddClaimAsync(user, new Claim("Permission", "Admin"));
                    break;
                case "Admin":
                    await _userManager.AddClaimAsync(user, new Claim("Permission", "SuperAdmin"));
                    break;
                default:
                    Console.WriteLine($"Ukendt rolle: {role}");
                    break;

            }
        }

    }
}

