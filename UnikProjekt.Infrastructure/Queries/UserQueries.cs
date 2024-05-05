using Microsoft.EntityFrameworkCore;
using UnikProjekt.Application.Queries.Users;
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
    }
}
