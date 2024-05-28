using UnikProjekt.Application.Commands.DTOs;
using UnikProjekt.Application.Helpers;
using UnikProjekt.Application.Repository;
using UnikProjekt.Domain.DomainService;
using UnikProjekt.Domain.Entities;
using UnikProjekt.Domain.Value;

namespace UnikProjekt.Application.Commands.Implementation;

public class UserCommand : IUserCommand
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _uow;
    private readonly IUserDomainService _userDomainService;
    private readonly IAddressDomainService _addressDomainService;

    public UserCommand(IUserRepository userRepository,
                       IUnitOfWork uow,
                       IUserDomainService userDomainService,
                       IAddressDomainService addressDomainService)
    {
        _userRepository = userRepository;
        _uow = uow;
        _userDomainService = userDomainService;
        _addressDomainService = addressDomainService;
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

            var name = new Name(createUserDto.FirstName,
                                createUserDto.LastName);
            var email = new EmailAddress(createUserDto.Email);
            var mobileNumber = new MobileNumber(createUserDto.MobileNumber);
            var address = new Address(createUserDto.Street,
                                      createUserDto.StreetNumber,
                                      createUserDto.PostCode,
                                      createUserDto.City);

            var user = User.Create(createUserDto.Id, name, email, mobileNumber, address, _userDomainService, _addressDomainService);

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

            //DO IT
            user.Update(name, email, mobileNumber, address);
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