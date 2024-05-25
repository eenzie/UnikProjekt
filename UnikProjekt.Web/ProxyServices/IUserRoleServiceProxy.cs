using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.ProxyServices
{
    public interface IUserRoleServiceProxy
    {
        Task<RoleDto> CreateUserRoleAsync(CreateUserRoleDto createUserRoleDto);

        Task<IEnumerable<RoleDto>> GetAllRolesAsync();
    }
}
