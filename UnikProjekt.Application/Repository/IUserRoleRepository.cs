using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Application.Repository;

public interface IUserRoleRepository
{
    void AddUserRole(UserRole userRole);
    List<UserRole> GetUserRoles(List<Guid> roleIds);
}
