using UnikProjekt.Application.Commands.DTOs;
using UnikProjekt.Application.Helpers;
using UnikProjekt.Application.Repository;
using UnikProjekt.Domain.Entities;

namespace UnikProjekt.Application.Commands.Implementation;

public class RoleCommand : IRoleCommand
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _uow;
    private readonly IServiceProvider _services;

    public RoleCommand(IRoleRepository roleRepository, IUnitOfWork uow, IServiceProvider services)
    {
        _roleRepository = roleRepository;
        _uow = uow;
        _services = services;
    }

    public Guid CreateRole(CreateRoleDto createRoleDto)
    {
        try
        {
            _uow.BeginTransaction();   //Isolation level is default: Serialized

            var role = Role.Create(createRoleDto.RoleName);

            _roleRepository.AddRole(role);

            _uow.Commit();

            return role.Id;
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

    public Guid UpdateRole(UpdateRoleDto updateRoleDto)
    {
        try
        {
            _uow.BeginTransaction(); //Isolation level is default: Serialized

            //READ
            var role = _roleRepository.GetRole(updateRoleDto.Id);

            if (role == null)
            {
                throw new Exception("Role not found");
            }

            //DO IT
            role.Update(updateRoleDto.RoleName);
            role.RowVersion = updateRoleDto.RowVersion;

            //SAVE
            _roleRepository.UpdateRole(role, updateRoleDto.RowVersion);

            _uow.Commit();

            return role.Id;
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
