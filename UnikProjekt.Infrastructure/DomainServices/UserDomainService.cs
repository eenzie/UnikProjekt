using UnikProjekt.Domain.DomainService;
using UnikProjekt.Domain.Value;
using UnikProjekt.Infrastructure.Database;

namespace UnikProjekt.Infrastructure.DomainServices
{
    public class UserDomainService : IUserDomainService
    {
        private readonly UnikDbContext _context;

        public UserDomainService(UnikDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Check if user with given email already exists in User table
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true if a user already exists</returns>
        public bool UserExistsWithEmail(EmailAddress email)
        {
            return _context.Users.Any(x => x.Email == email);
        }
    }
}
