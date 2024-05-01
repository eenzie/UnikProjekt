using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Application.Repository
{
    public interface IUserRepository
    {
        User GetUser(Guid userId);
    }
}
