using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Application.Commands;
using UnikProjekt.Application.Commands.DTOs;
using UnikProjekt.Application.Queries;
using UnikProjekt.Application.Queries.DTOs;

namespace UnikProjekt.Api.Controller;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserQueries _userQueries;
    private readonly IUserCommand _userCommand;

    public UserController(IUserQueries userQueries, IUserCommand userCommand)
    {
        _userQueries = userQueries;
        _userCommand = userCommand;
    }

    //TODO: INA: AsUserDto Func nødvendig?
    //private static readonly Expression<Func<User, UserDto>> AsUserDto =
    //        x => new UserDto
    //        {
    //            Name = x.Name.ToString(),
    //            Email = x.Email.ToString(),
    //            MobileNumber = x.MobileNumber.ToString()
    //        };

    //GET: User
    [HttpGet]
    public IEnumerable<UserDto> Get()
    {
        return _userQueries.GetAllUsers();
    }

    // GET: User
    [HttpGet("ById/{userId}")]
    public IEnumerable<UserDto> Get(Guid userId)
    {
        return _userQueries.GetUserById(userId);
    }

    //GET: User
    [HttpGet("ByName, {searchTerm}")]
    public IEnumerable<UserDto> Get(string searchTerm)
    {
        return _userQueries.GetUserByName(searchTerm);
    }

    //POST: User
    [HttpPost("Create")]
    public void CreateUser([FromBody] CreateUserDto user)
    {
        var userToCreate = new CreateUserDto
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            MobileNumber = user.MobileNumber
        };

        _userCommand.CreateUser(userToCreate);
    }
}
