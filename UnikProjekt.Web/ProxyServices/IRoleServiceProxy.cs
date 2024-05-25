using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.ProxyServices
{
    public interface IRoleServiceProxy
    {
        Task<IEnumerable<RoleDto>?> GetAllRolesAsync();
        Task<RoleDto> GetRoleByIdAsync(Guid id);
        Task<IEnumerable<RoleDto>> GetRoleByNameAsync(string name);
        Task<RoleDto> CreateRoleAsync(CreateRoleDto createRoleDto);
        Task<RoleDto> EditRoleAsync(Guid id, EditRoleDto editRoleDto);
    }
}
