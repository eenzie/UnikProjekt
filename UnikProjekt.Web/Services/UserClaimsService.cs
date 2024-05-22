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
                case "SuperAdmin":
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
                    await _userManager.AddClaimAsync(user, new Claim("Permission", "SuperUserPermission"));
                    break;
                case "Admin":
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
                    await _userManager.AddClaimAsync(user, new Claim("Permission", "AdminPermission"));
                    break;
                case "User":
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
                    await _userManager.AddClaimAsync(user, new Claim("Permission", "UserPermission"));
                    break;
                case "Reader":
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
                    await _userManager.AddClaimAsync(user, new Claim("Permission", "ReaderPermission"));
                    break;
                default:
                    Console.WriteLine($"Ukendt rolle: {role}");
                    break;


                    //eller giver det her bedre mening: 
                    switch (role)
                    {
                        case "Beboer":
                            await _userManager.AddClaimAsync(user, new Claim("Permission", "Reader"));
                        case "Menig":
                            await _userManager.AddClaimAsync(user, new Claim("Permission", "Reader"));
                        case "Sekretær":
                            await _userManager.AddClaimAsync(user, new Claim("Permission", "User"));
                        case "Kasser":
                            await _userManager.AddClaimAsync(user, new Claim("Permission", "User"));
                        case "NæstFormand":
                            await _userManager.AddClaimAsync(user, new Claim("Permission", "Admin"));
                        case "Formand":
                            await _userManager.AddClaimAsync(user, new Claim("Permission", "Admin"));
                        case "Admin":
                            await _userManager.AddClaimAsync(user, new Claim("Permission", "SuperAdmin"));
                        default:
                            Console.WriteLine($"Ukendt rolle: {role}");
                            break;

                    }
            }

        }
    }
}
