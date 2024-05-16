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
        var role = _context.Roles
        .AsNoTracking()   //LOAD
            .Where(x => x.Id == roleId)
            .Select(x => new RoleDto  //TRANSFORM
            {
                Id = x.Id,
                RoleName = x.RoleName.ToString(),
                RowVersion = x.RowVersion
            })
            .FirstOrDefault();

        return role;  //RETURN
    }

    IEnumerable<RoleDto> IRoleQueries.GetRoleByName(string roleName)
    {
        var result = _context.Roles
       .AsNoTracking()
           .Where(x => x.RoleName.Contains(roleName))
           .Select(x => new RoleDto
           {
               Id = x.Id,
               RoleName = x.RoleName.ToString(),
               RowVersion = x.RowVersion
           })
           .ToList();

        return result;
    }
}
