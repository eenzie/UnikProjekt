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
    }
}
