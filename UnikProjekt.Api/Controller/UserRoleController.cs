using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Application.Commands;
using UnikProjekt.Application.Commands.DTOs;
using UnikProjekt.Application.Queries;

namespace UnikProjekt.Api.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {

        private readonly IUserRoleQueries _userRoleQueries;
        private readonly IUserRoleCommand _userRoleCommand;

        public UserRoleController(IUserRoleQueries userRoleQueries, IUserRoleCommand userRoleCommand)
        {
            _userRoleQueries = userRoleQueries;
            _userRoleCommand = userRoleCommand;
        }

        // POST UserRole
        [HttpPost(Name = "CreateUserRole")]
        public IActionResult Create([FromBody] CreateUserRoleDto userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userRoleToCreate = new CreateUserRoleDto
            {
                UserId = userRole.UserId,
                RoleId = userRole.RoleId,
                StartDate = userRole.StartDate,
                EndDate = userRole.EndDate
            };

            _userRoleCommand.CreateUserRole(userRoleToCreate);

            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT UserRole
        [HttpPut(Name = "UpdateUserRole")]
        public IActionResult UpdateUserRole([FromBody] UpdateUserRoleDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userRoleToUpdate = new UpdateUserRoleDto
            {
                UserId = user.UserId,
                RoleId = user.RoleId,
                StartDate = user.StartDate,
                EndDate = user.EndDate,
                RowVersion = user.RowVersion
            };

            var userId = _userRoleCommand.UpdateUserRole(userRoleToUpdate);

            if (userId == Guid.Empty)
            {
                return NotFound();
            }

            return CreatedAtAction("GetUserRoleByUserId", new { UserId = userId }, userRoleToUpdate);
        }
    }
}
