using UnikProjekt.Application.Commands.DTOs;

namespace UnikProjekt.Application.Commands;

public interface IUserCommand
{
    Guid CreateUser(CreateUserDto createUserDto);
    Guid UpdateUser(UpdateUserDto updateUserDto);
}
