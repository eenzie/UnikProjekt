using UnikProjekt.Application.Queries.DTOs;

namespace UnikProjekt.Application.Queries;

public interface IRoleQueries
{
    IEnumerable<RoleDto> GetAllRoles();
    RoleDto? GetRoleById(Guid roleId);
    IEnumerable<RoleDto> GetRoleByName(string roleName);
}
