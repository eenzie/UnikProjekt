using UnikProjekt.Application.Commands.DTOs;
using UnikProjekt.Application.Helpers;
using UnikProjekt.Application.Repository;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Domain.Value;

namespace UnikProjekt.Application.Commands.Implementation;

public class UserRoleCommand : IUserRoleCommand
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _uow;
    private readonly IServiceProvider _services;

    public UserRoleCommand(IUserRoleRepository userRoleRepository, IUnitOfWork uow, IServiceProvider services, IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _userRoleRepository = userRoleRepository;
        _uow = uow;
        _services = services;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }
    public void CreateUserRole(CreateUserRoleDto createUserRoleDto)
    {
        try
        {
            _uow.BeginTransaction();   //Default isolation level: Serializable

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

    Guid IUserRoleCommand.UpdateUserRole(UpdateUserRoleDto updateUserRoleDto)
    {
        try
        {
            _uow.BeginTransaction();   //Default isolation level: Serializable

            //READ
            var userRole = _userRoleRepository.GetUserRoleByIds(updateUserRoleDto.UserId, updateUserRoleDto.RoleId);

            if (userRole == null)
            {
                throw new Exception("User Role not found");
            }

            var roleDates = new RoleDates(updateUserRoleDto.StartDate, updateUserRoleDto.EndDate);

            //DO IT
            userRole.Update(updateUserRoleDto.UserId, updateUserRoleDto.RoleId, roleDates);
            userRole.RowVersion = updateUserRoleDto.RowVersion;


            //SAVE
            _userRoleRepository.UpdateUserRole(userRole, updateUserRoleDto.RowVersion);

            _uow.Commit();

            return userRole.UserId;
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
