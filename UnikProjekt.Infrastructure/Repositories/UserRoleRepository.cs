using UnikProjekt.Application.Repository;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Infrastructure.Database;

namespace UnikProjekt.Infrastructure.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly UnikDbContext _context;

    public UserRoleRepository(UnikDbContext context)
    {
        _context = context;
    }

    List<UserRole> IUserRoleRepository.GetUserRoles(List<Guid> roleIds)
    {
        var result = new List<UserRole>();

        foreach (var id in roleIds)
        {
            result.Add(_context.UserRoles.First(x => x.UserId == id));
        }
        return result;
    }
}
