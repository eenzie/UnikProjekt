using UnikProjekt.Application.Queries.DTOs;

namespace UnikProjekt.Application.Queries;

public interface IUserQueries
{
    IEnumerable<UserDto> GetUserById(Guid userId);
}
