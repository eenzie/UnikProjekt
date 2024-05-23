using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using UnikProjekt.Web.Data;
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

        public async Task AssignClaimsAsync(ApplicationUser user, string role, bool isNewUser)
        {
            IList<Claim> claims = new List<Claim>();

            if (isNewUser)
            {
                switch (role)
                {
                    case "Beboer":
                        claims.Add(new Claim(ClaimTypes.Role, ClaimsTypes.UserTypeList[3])); // Reader
                        break;
                    case "Admin":
                        claims.Add(new Claim(ClaimTypes.Role, ClaimsTypes.UserTypeList[0])); // SuperAdmin
                        break;
                    default:
                        Console.WriteLine($"Ukendt rolle: {role}");
                        break;
                }
            }
            else
            {
                switch (role)
                {
                    case "Beboer":
                    case "Menig":
                        claims.Add(new Claim(ClaimTypes.Role, ClaimsTypes.UserTypeList[3])); // Reader
                        break;
                    case "Sekretær":
                    case "Kasser":
                        claims.Add(new Claim(ClaimTypes.Role, ClaimsTypes.UserTypeList[2])); // User
                        break;
                    case "NæstFormand":
                    case "Formand":
                        claims.Add(new Claim(ClaimTypes.Role, ClaimsTypes.UserTypeList[1])); // Admin
                        break;
                    case "Admin":
                        claims.Add(new Claim(ClaimTypes.Role, ClaimsTypes.UserTypeList[0])); // SuperAdmin
                        break;
                    default:
                        Console.WriteLine($"Ukendt rolle: {role}");
                        break;
                }
            }

            // Tildel alle claims til brugeren
            foreach (var claim in claims)
            {
                await _userManager.AddClaimAsync(user, claim);
            }
        }
    }

}

