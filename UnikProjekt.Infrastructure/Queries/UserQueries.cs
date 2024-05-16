using Microsoft.EntityFrameworkCore;
using UnikProjekt.Application.Queries;
using UnikProjekt.Application.Queries.DTOs;
using UnikProjekt.Infrastructure.Database;

namespace UnikProjekt.Infrastructure.Queries;

public class UserQueries : IUserQueries
{
    private readonly UnikDbContext _context;

    public UserQueries(UnikDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets all users from database
    /// </summary>
    /// <returns>List of users</returns>
    IEnumerable<UserDto> IUserQueries.GetAllUsers()
    {
        return _context.Users.AsNoTracking()
            .Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name.ToString(),
                Email = x.Email.ToString(),
                MobileNumber = x.MobileNumber.ToString(),
                Address = x.Address.ToString(),
                RoleIds = x.UserRoles.Select(r => r.RoleId).ToList(),
                RowVersion = x.RowVersion
            })
            .ToList();
    }

    /// <summary>
    /// Gets user by Guid
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>First or default user with Guid</returns>
    UserDto? IUserQueries.GetUserById(Guid userId)
    {
        var user = _context.Users
            .AsNoTracking()   //LOAD
            .Where(x => x.Id == userId)
            .Select(x => new UserDto  //TRANSFORM
            {
                Id = x.Id,
                Name = x.Name.ToString(),
                Email = x.Email.ToString(),
                MobileNumber = x.MobileNumber.ToString(),
                Address = x.Address.ToString(),
                RoleIds = x.UserRoles.Select(r => r.RoleId).ToList(),
                RowVersion = x.RowVersion
            })
            .FirstOrDefault();

        return user;  //RETURN
    }

    /// <summary>
    /// Gets user where first name or last name contains search term
    /// </summary>
    /// <param name="searchTerm"></param>
    /// <returns>User with first or last name containing search term</returns>
    IEnumerable<UserDto> IUserQueries.GetUserByName(string searchTerm)
    {
        var result = _context.Users
        .AsNoTracking()
            .Where(x => x.Name.FirstName.Contains(searchTerm))
            .Union(_context.Users.AsNoTracking().Where(x => x.Name.LastName.Contains(searchTerm)))
            .Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name.ToString(),
                Email = x.Email.ToString(),
                MobileNumber = x.MobileNumber.ToString(),
                Address = x.Address.ToString(),
                RoleIds = x.UserRoles.Select(r => r.RoleId).ToList(),
                RowVersion = x.RowVersion
            })
            .ToList();

        return result;
    }
}
