using UnikProjekt.Application.Commands.DTOs;
using UnikProjekt.Application.Helpers;
using UnikProjekt.Application.Repository;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Domain.Value;

namespace UnikProjekt.Application.Commands.Implementation;

public class UserRoleCommand : IUserRoleCommand
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUnitOfWork _uow;
    private readonly IServiceProvider _services;

    public UserRoleCommand(IUserRoleRepository userRoleRepository, IUnitOfWork uow, IServiceProvider services)
    {
        _userRoleRepository = userRoleRepository;
        _uow = uow;
        _services = services;
    }
    public void CreateUserRole(CreateUserRoleDto createUserRoleDto)
    {
        try
        {
            _uow.BeginTransaction();   //Isolation level is default: Serialized

            var roleDates = new RoleDates(createUserRoleDto.StartDate, createUserRoleDto.EndDate);

            var userRole = UserRole.Create(createUserRoleDto.UserId, createUserRoleDto.RoleId, roleDates);

            _userRoleRepository.AddUserRole(userRole);

            _uow.Commit();

        }
        catch (Exception e)
        {
            try
            {
                _uow.Rollback();
            }
            catch (Exception ex)
            {
                throw new Exception($"Rollback failed: {ex.Message}", e);
            }
            throw;
        }
    }
}
