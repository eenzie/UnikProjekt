using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Application.Repository;

public interface IUserRoleRepository
{
    List<UserRole> GetUserRoles(List<Guid> roleIds);
}
