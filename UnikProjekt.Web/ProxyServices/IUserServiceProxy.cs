using UnikProjekt.Web.Models.DTOs;

namespace UnikProjekt.Web.ProxyServices
{
    public interface IUserServiceProxy
    {
        Task<IEnumerable<UserDto>?> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(Guid id);
        Task<IEnumerable<UserDto>> GetUserByNameAsync(string name);
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserDto> EditUserAsync(EditUserDto editUserDto);
    }
}
