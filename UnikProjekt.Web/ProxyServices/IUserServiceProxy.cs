using UnikProjekt.Web.Models;
using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.ProxyServices
{
    public interface IUserServiceProxy
    {
        Task<IEnumerable<UserViewModel>?> GetAllUsers();
        Task<UserViewModel?> GetUserById(Guid id);
        Task<IEnumerable<UserViewModel>> GetUserByName(string name);
        Task<UserViewModel> CreateUser(CreateUserDto createUserDto);
        Task<UserViewModel> EditUser(Guid id, UserViewModel updatedUser);


    }
}
