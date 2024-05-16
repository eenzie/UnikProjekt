using UnikProjekt.Application.Commands.DTOs;
using UnikProjekt.Application.Helpers;
using UnikProjekt.Application.Repository;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Domain.Value;

namespace UnikProjekt.Application.Commands.Implementation;

public class UserCommand : IUserCommand
{
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUnitOfWork _uow;
    private readonly IServiceProvider _services;

    public UserCommand(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IUnitOfWork uow, IServiceProvider services)
    {
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _uow = uow;
        _services = services;
    }

    /// <summary>
    /// Creates new user
    /// </summary>
    /// <param name="createUserDto"></param>
    /// <returns>Guid of created user</returns>
    /// <exception cref="Exception"></exception>
    Guid IUserCommand.CreateUser(CreateUserDto createUserDto)
    {
        try
        {
            _uow.BeginTransaction();   //Isolation level is default: Serialized

            var name = new Name(createUserDto.FirstName, createUserDto.LastName);
            var email = new EmailAddress(createUserDto.Email);
            var mobileNumber = new MobileNumber(createUserDto.MobileNumber);
            var address = new Address(createUserDto.Street,
                                      createUserDto.StreetNumber,
                                      createUserDto.PostCode,
                                      createUserDto.City);
            var roles = _userRoleRepository.GetUserRoles(createUserDto.UserRoles);

            var user = User.Create(name, email, mobileNumber, address, roles);

            _userRepository.AddUser(user);

            _uow.Commit();

            return user.Id;
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

    /// <summary>
    /// Updates user details
    /// </summary>
    /// <param name="updateUserDto"></param>
    /// <returns>Guid of the updated user</returns>
    /// <exception cref="Exception"></exception>
    Guid IUserCommand.UpdateUser(UpdateUserDto updateUserDto)
    {
        try
        {
            _uow.BeginTransaction(); //Isolation level is default: Serialized

            //READ
            var user = _userRepository.GetUser(updateUserDto.Id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var name = new Name(updateUserDto.FirstName, updateUserDto.LastName);
            var email = new EmailAddress(updateUserDto.Email);
            var mobileNumber = new MobileNumber(updateUserDto.MobileNumber);
            var address = new Address(updateUserDto.Street,
                                      updateUserDto.StreetNumber,
                                      updateUserDto.PostCode,
                                      updateUserDto.City);
            var roles = _userRoleRepository.GetUserRoles(updateUserDto.UserRoles);

            //DO IT
            user.Update(name, email, mobileNumber, address, roles);
            user.RowVersion = updateUserDto.RowVersion;


            //SAVE
            _userRepository.UpdateUser(user, updateUserDto.RowVersion);

            _uow.Commit();

            return user.Id;
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
