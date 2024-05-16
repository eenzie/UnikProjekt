using Microsoft.EntityFrameworkCore;
using UnikProjekt.Application.Queries;
using UnikProjekt.Application.Queries.DTOs;
using UnikProjekt.Infrastructure.Database;

namespace UnikProjekt.Infrastructure.Queries;

public class RoleQueries : IRoleQueries
{
    private readonly UnikDbContext _context;

    public RoleQueries(UnikDbContext context)
    {
        _context = context;
    }

    IEnumerable<RoleDto> IRoleQueries.GetAllRoles()
    {
        return _context.Roles.AsNoTracking()
           .Select(x => new RoleDto
           {
               Id = x.Id,
               RoleName = x.RoleName.ToString(),
               RowVersion = x.RowVersion
           })
           .ToList();
    }

    RoleDto? IRoleQueries.GetRoleById(Guid roleId)
    {
        throw new NotImplementedException();
    }

    IEnumerable<RoleDto> IRoleQueries.GetRoleByName(string roleName)
    {
        throw new NotImplementedException();
    }
}
