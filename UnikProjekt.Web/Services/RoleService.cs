using UnikProjekt.Web.Models;
using UnikProjekt.Web.Models.DTOs;
using UnikProjekt.Web.ProxyServices;

namespace UnikProjekt.Web.Services
{
    public class RoleService
    {
        private readonly IRoleServiceProxy _roleServiceProxy;

        public RoleService(IRoleServiceProxy roleServiceProxy)
        {
            _roleServiceProxy = roleServiceProxy;
        }

        public async Task<IEnumerable<RoleViewModel>> GetAllRolesAsync()
        {
            var roleDtos = await _roleServiceProxy.GetAllRolesAsync();
            if (roleDtos == null)
            {
                return null;
            }

            var roleViewModels = roleDtos.Select(roleDto => new RoleViewModel
            {
                Id = roleDto.Id,
                RoleName = roleDto.RoleName,
            });

            return roleViewModels;
        }

        public async Task<RoleViewModel> GetRoleByIdAsync(Guid id)
        {
            var roleDto = await _roleServiceProxy.GetRoleByIdAsync(id);
            return new RoleViewModel
            {
                Id = roleDto.Id,
                RoleName = roleDto.RoleName,
            };
        }

        public async Task<IEnumerable<RoleViewModel>> GetRoleByNameAsync(string name)
        {
            var roleDto = await _roleServiceProxy.GetRoleByNameAsync(name);
            return roleDto.Select(roleDto => new RoleViewModel
            {
                Id = roleDto.Id,
                RoleName = roleDto.RoleName,
            });
        }

        public async Task<Guid> CreateRoleAsync(CreateRoleDto createRoleDto)
        {
            var roleDto = await _roleServiceProxy.CreateRoleAsync(createRoleDto);
            if (roleDto == null)
            {
                return Guid.Empty;
            }

            return roleDto.Id;
        }

        public async Task<Guid> EditRoleAsync(Guid id, EditRoleDto editRoleDto)
        {
            var editedRoleDto = await _roleServiceProxy.EditRoleAsync(id, editRoleDto);
            if (editedRoleDto == null)
            {
                return Guid.Empty;
            }

            return editedRoleDto.Id;

        }
    }
}
