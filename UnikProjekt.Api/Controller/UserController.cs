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
    /// <summary>
    /// GET: User/Abc
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
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

    /// <summary>
    /// POST: User
    /// </summary>
    /// <param name="user"></param>
    /// <returns>400 BadRequest, 404 NotFound, 201 Created</returns>
    [HttpPost(Name = "CreateUser")]
    public IActionResult Create([FromBody] CreateUserDto user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var userToCreate = new CreateUserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            MobileNumber = user.MobileNumber,
            Street = user.Street,
            StreetNumber = user.StreetNumber,
            PostCode = user.PostCode,
            City = user.City,
        };

        var userId = _userCommand.CreateUser(userToCreate);

        if (userId == Guid.Empty)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating the user");
        }
        //Http Status code '201 Created'
        return StatusCode(StatusCodes.Status201Created);
    }

    /// <summary>
    /// PUT: User
    /// </summary>
    /// <param name="user"></param>
    /// <returns>400 BadRequest, 404 NotFound, 201 Created</returns>
    [HttpPut(Name = "UpdateUser")]
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
            Street = user.Street,
            StreetNumber = user.StreetNumber,
            PostCode = user.PostCode,
            City = user.City,
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
