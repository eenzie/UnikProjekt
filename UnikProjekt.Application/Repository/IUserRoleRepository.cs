using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Application.Repository;

public interface IUserRoleRepository
{
    List<UserRole> GetUserRoles(List<Guid> roleIds);
    UserRole GetUserRoleByIds(Guid userId, Guid roleId);
    void AddUserRole(UserRole userRole);
    void UpdateUserRole(UserRole userRole, byte[] rowVersion);
}
