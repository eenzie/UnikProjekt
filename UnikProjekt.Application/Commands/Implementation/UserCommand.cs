using UnikProjekt.Application.Commands.DTOs;
using UnikProjekt.Application.Helpers;
using UnikProjekt.Application.Repository;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Domain.Value;

namespace UnikProjekt.Application.Commands.Implementation;

public class UserCommand : IUserCommand
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _uow;
    private readonly IServiceProvider _services;

    public UserCommand(IUserRepository userRepository, IUnitOfWork uow, IServiceProvider services)
    {
        _userRepository = userRepository;
        _uow = uow;
        _services = services;
    }

    void IUserCommand.CreateUser(CreateUserDto createUserDto)
    {
        try
        {
            _uow.BeginTransaction();   //Isolation level is default: Serialized

            var name = new Name(createUserDto.FirstName, createUserDto.LastName);
            var email = new EmailAddress(createUserDto.Email);
            var mobileNumber = new MobileNumber(createUserDto.MobileNumber);

            var user = User.Create(name, email, mobileNumber);

            _userRepository.AddUser(user);

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

    void IUserCommand.UpdateUser(UpdateUserDto updateUserDto)
    {
        try
        {
            _uow.BeginTransaction(); //TODO: INA: Check isolation level correct for Update?

            //READ
            var user = _userRepository.GetUser(updateUserDto.Id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var name = new Name(updateUserDto.FirstName, updateUserDto.LastName);
            var email = new EmailAddress(updateUserDto.Email);
            var mobileNumber = new MobileNumber(updateUserDto.MobileNumber);

            //DO IT
            user.Update(updateUserDto.Id, name, email, mobileNumber, updateUserDto.RowVersion);

            //SAVE
            _userRepository.UpdateUser(user);

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
