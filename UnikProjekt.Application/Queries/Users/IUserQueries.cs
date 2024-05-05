namespace UnikProjekt.Application.Queries.Users;

public interface IUserQueries
{
    IEnumerable<UserDto> GetUserById(Guid userId);
}
