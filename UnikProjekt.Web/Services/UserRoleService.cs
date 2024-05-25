using UnikProjekt.Web.Models;
using UnikProjekt.Web.Models.DTOs;
using UnikProjekt.Web.ProxyServices;

namespace UnikProjekt.Web.Services
{
    public class UserRoleService
    {
        private readonly IUserRoleServiceProxy _userRoleServiceProxy;

        public UserRoleService(IUserRoleServiceProxy userRoleServiceProxy)
        {
            _userRoleServiceProxy = userRoleServiceProxy;
        }

        public async Task<Guid> CreateUserRoleAsync(CreateUserRoleDto createUserRoleDto)
        {
            //calling backend method _userRoleServiceProxy.CreateUserRoleAsync
            var userRoleDto = await _userRoleServiceProxy.CreateUserRoleAsync(createUserRoleDto);
            if (userRoleDto == null)
            {
                return Guid.Empty;
            }

            return userRoleDto.Id;
        }

        public async Task<IEnumerable<RoleViewModel>> GetAllRolesAsync()
        {
            var roleDtos = await _userRoleServiceProxy.GetAllRolesAsync();
            var roleViewModels = roleDtos.Select(roleDto => new RoleViewModel
            {
                Id = roleDto.Id,
                RoleName = roleDto.RoleName
            });
            return roleViewModels;
        }
    }
}

