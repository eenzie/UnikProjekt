using UnikProjekt.Application.Queries.DTOs;

namespace UnikProjekt.Application.Queries;

public interface IUserQueries
{
    IEnumerable<UserDto> GetAllUsers();
    UserDto? GetUserById(Guid userId);
    IEnumerable<UserDto> GetUserByName(string name);
}
