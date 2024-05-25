using UnikProjekt.Application.Commands.DTOs;

namespace UnikProjekt.Application.Commands;

public interface IUserRoleCommand
{
    void CreateUserRole(CreateUserRoleDto createUserRoleDto);
    Guid UpdateUserRole(UpdateUserRoleDto updateUserRoleDto);
}
