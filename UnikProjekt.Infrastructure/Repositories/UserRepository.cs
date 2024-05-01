using UnikProjekt.Application.Repository;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Infrastructure.Database;

namespace UnikProjekt.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UnikDbContext _context;

    public UserRepository(UnikDbContext context)
    {
        _context = context;
    }

    public User GetUser(Guid userId)
    {
        return _context.Users.Find(userId) ?? throw new Exception("User not found");
    }
}
