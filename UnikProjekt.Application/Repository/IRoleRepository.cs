using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Application.Repository;

public interface IRoleRepository
{
    Role GetRole(Guid roleId);
    Guid AddRole(Role role);
    void UpdateRole(Role role, byte[] rowVersion);
    List<Role> GetRoles(List<string> roles);
}
