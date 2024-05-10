using UnikProjekt.Application.Commands.DTOs;

namespace UnikProjekt.Application.Commands;

public interface IUserCommand
{
    void CreateUser(CreateUserDto createUserDto);
    void UpdateUser(UpdateUserDto updateUserDto);
}
