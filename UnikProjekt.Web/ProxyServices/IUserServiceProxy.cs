using UnikProjekt.Web.Models;
using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.ProxyServices
{
    public interface IUserServiceProxy
    {
        Task<IEnumerable<UserViewModel>?> GetAllUsersAsync();
        Task<UserViewModel?> GetUserByIdAsync(Guid id);
        Task<IEnumerable<UserViewModel>> GetUserByNameAsync(string name);
        Task<UserViewModel> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserViewModel> EditUserAsync(Guid id, UserViewModel updatedUser);

        Task<DocumentViewModel> CreateDocumentAsync(CreateDocumentDto createDocumentDto);


    }


}
