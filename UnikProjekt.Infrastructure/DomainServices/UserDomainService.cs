using UnikProjekt.Domain.DomainService;
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
    }
}
