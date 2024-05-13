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
    public ActionResult<IEnumerable<UserDto>> Get()
    {
        var result = _userQueries.GetAllUsers();

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    // GET: User/5
    [HttpGet("{id:guid}", Name = "GetUserById")]
    public ActionResult<UserDto> GetUserById(Guid id)
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
    public IActionResult Create([FromBody] CreateUserDto user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var userToCreate = new CreateUserDto
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            MobileNumber = user.MobileNumber
        };

        var userId = _userCommand.CreateUser(userToCreate);

        if (userId == Guid.Empty)
        {
            return NotFound();
        }

        return CreatedAtAction("GetUserById", new { Id = userId }, userToCreate);
    }

    //PUT: User
    [HttpPut(Name = "Update")]
    public IActionResult Update([FromBody] UpdateUserDto user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var userToUpdate = new UpdateUserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            MobileNumber = user.MobileNumber,
            RowVersion = user.RowVersion
        };

        var userId = _userCommand.UpdateUser(userToUpdate);

        if (userId == Guid.Empty)
        {
            return NotFound();
        }

        return CreatedAtAction("GetUserById", new { Id = userId }, userToUpdate);
    }
}
