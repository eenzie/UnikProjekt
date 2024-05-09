using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Application.Queries;
using UnikProjekt.Application.Queries.DTOs;

namespace UnikProjekt.Api.Controller;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserQueries _userQueries;

    public UserController(IUserQueries userQueries)
    {
        _userQueries = userQueries;
    }

    //TODO: INA: AsUserDto Func nødvendig?
    //private static readonly Expression<Func<User, UserDto>> AsUserDto =
    //        x => new UserDto
    //        {
    //            Name = x.Name.ToString(),
    //            Email = x.Email.ToString(),
    //            MobileNumber = x.MobileNumber.ToString()
    //        };

    //GET: api/Users
    [HttpGet]
    public IEnumerable<UserDto> Get()
    {
        return _userQueries.GetAllUsers();
    }

    // GET: api/Users
    [HttpGet("ById, {userId}")]
    public IEnumerable<UserDto> Get(Guid userId)
    {
        return _userQueries.GetUserById(userId);
    }

    //GET: api/Users
    [HttpGet("ByName, {searchTerm}")]
    public IEnumerable<UserDto> Get(string searchTerm)
    {
        return _userQueries.GetUserByName(searchTerm);
    }
}
