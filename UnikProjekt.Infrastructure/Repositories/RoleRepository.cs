using UnikProjekt.Application.Repository;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Infrastructure.Database;

namespace UnikProjekt.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly UnikDbContext _context;

    public RoleRepository(UnikDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets Roles from string list of roles. Such as on Create/Update User
    /// </summary>
    /// <param name="roles"></param>
    /// <returns>Listof Role Entity</returns>
    List<Role> IRoleRepository.GetRoles(List<string> roles)
    {
        var result = new List<Role>();

        foreach (var role in roles)
        {
            result.Add(_context.Roles.First(x => x.RoleName == role));
        }
        return result;
    }

    Role IRoleRepository.GetRole(Guid roleId)
    {
        throw new NotImplementedException();
    }

    Guid IRoleRepository.AddRole(Role role)
    {
        throw new NotImplementedException();
    }

    void IRoleRepository.UpdateRole(Role role, byte[] rowVersion)
    {
        throw new NotImplementedException();
    }
}
