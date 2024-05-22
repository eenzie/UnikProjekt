using UnikProjekt.Application.Commands.DTOs;

namespace UnikProjekt.Application.Commands;

public interface IRoleCommand
{
    Guid CreateRole(CreateRoleDto createRoleDto);
    Guid UpdateRole(UpdateRoleDto updateRoleDto);
}
