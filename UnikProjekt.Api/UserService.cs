using Microsoft.AspNetCore.Identity;

namespace UnikProjekt.Api
{
    public class UserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void CreateUserAndAssignRole(string email, string password, string roleId)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            var result = _userManager.CreateAsync(user, password).GetAwaiter().GetResult();

            if (!result.Succeeded)
            {
                throw new Exception($"Failed to create user");
            }

            if (!_roleManager.RoleExistsAsync(roleId).GetAwaiter().GetResult())
            {
                var role = new IdentityRole { Name = roleId };
                var roleResult = _roleManager.CreateAsync(role).GetAwaiter().GetResult();
                if (!roleResult.Succeeded)
                {
                    throw new Exception($"Failed to create role");
                }
            }

            var addToRoleResult = _userManager.AddToRoleAsync(user, roleId).GetAwaiter().GetResult();
            if (!addToRoleResult.Succeeded)
            {
                throw new Exception($"Failed to assign role to user");
            }
        }
    }
}
