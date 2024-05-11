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

    //GET: User
    [HttpGet]
    public IEnumerable<UserDto> Get()
    {
        return _userQueries.GetAllUsers();
    }

    // GET: User/5
    [HttpGet("{id:guid}", Name = "GetUserById")]
    public IActionResult GetUserById(Guid id)
    {
        var result = _userQueries.GetUserById(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    //GET: User/JohnDoe
    [HttpGet("{name}", Name = "GetUserByName")]
    public IActionResult GetUserByName(string name)
    {
        var result = _userQueries.GetUserByName(name);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }


    //POST: User
    [HttpPost(Name = "Create")]
    public void Create([FromBody] CreateUserDto user)
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

    //PUT: User
    [HttpPut(Name = "Update")]
    public void Update([FromBody] UpdateUserDto user)
    {
        var userToUpdate = new UpdateUserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            MobileNumber = user.MobileNumber,
            RowVersion = user.RowVersion
        };

        _userCommand.UpdateUser(userToUpdate);
    }
}
