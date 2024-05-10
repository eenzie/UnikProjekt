using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Application.Repository
{
    public interface IUserRepository
    {
        User GetUser(Guid userId);
        void AddUser(User user);
        void UpdateUser(User user);
    }
}
