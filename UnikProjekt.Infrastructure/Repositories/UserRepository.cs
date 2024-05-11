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

    void IUserRepository.AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    void IUserRepository.UpdateUser(User user)
    {
        _context.Update(user);
        _context.SaveChanges();
    }
}