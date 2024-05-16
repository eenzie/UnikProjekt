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

    User IUserRepository.GetUser(Guid userId)
    {
        return _context.Users.Find(userId) ?? throw new Exception("User not found");
    }

    Guid IUserRepository.AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user.Id;
    }

    void IUserRepository.UpdateUser(User user, byte[] rowVersion)
    {
        _context.Entry(user).Property(p => p.RowVersion).OriginalValue = rowVersion;
        _context.SaveChanges();
    }
}