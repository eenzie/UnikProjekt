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

    // GET: api/User
    [HttpGet]
    public IEnumerable<UserDto> Get(Guid userId)
    {
        return _userQueries.GetUserById(userId);
    }
}
