using Microsoft.EntityFrameworkCore;
using UnikProjekt.Application.Queries;
using UnikProjekt.Application.Queries.DTOs;
using UnikProjekt.Infrastructure.Database;

namespace UnikProjekt.Infrastructure.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly UnikDbContext _context;

        public UserQueries(UnikDbContext context)
        {
            _context = context;
        }

        IEnumerable<UserDto> IUserQueries.GetAllUsers()
        {
            return _context.Users.AsNoTracking().Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name.ToString(),
                Email = x.Email.ToString(),
                MobileNumber = x.MobileNumber.ToString(),
                RowVersion = x.RowVersion
            })
                .ToList();
        }

        IEnumerable<UserDto> IUserQueries.GetUserById(Guid userId)
        {
            var result = _context.Users
                .AsNoTracking()
                .Where(x => x.Id == userId)
                .Select(x => new UserDto
                {
                    Id = x.Id,
                    Name = x.Name.ToString(),
                    Email = x.Email.ToString(),
                    MobileNumber = x.MobileNumber.ToString(),
                    RowVersion = x.RowVersion
                })
                .ToList();

            return result;
        }


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
                    RowVersion = x.RowVersion
                })
                .ToList();

            return result;
        }
    }
}
