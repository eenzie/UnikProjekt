using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Application.Commands;
using UnikProjekt.Application.Commands.DTOs;
using UnikProjekt.Application.Queries;
using UnikProjekt.Application.Queries.DTOs;

namespace UnikProjekt.Api.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleQueries _roleQueries;
        private readonly IRoleCommand _roleCommand;

        public RoleController(IRoleQueries roleQueries, IRoleCommand roleCommand)
        {
            _roleQueries = roleQueries;
            _roleCommand = roleCommand;
        }

        // GET: Role
        [HttpGet]
        public ActionResult<IEnumerable<RoleDto>> Get()
        {
            var result = _roleQueries.GetAllRoles();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET Role/5
        [HttpGet("{id:guid}", Name = "GetRoleById")]
        public ActionResult<RoleDto> GetRoleById(Guid id)
        {
            var result = _roleQueries.GetRoleById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        //GET: Role/Abc
        [HttpGet("{name}", Name = "GetRoleByName")]
        public IActionResult GetRoleByName(string name)
        {
            var result = _roleQueries.GetRoleByName(name);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST Role
        [HttpPost(Name = "CreateRole")]
        public IActionResult Create([FromBody] CreateRoleDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roleToCreate = new CreateRoleDto
            {
                RoleName = user.RoleName
            };

            var roleId = _roleCommand.CreateRole(roleToCreate);

            if (roleId == Guid.Empty)
            {
                return NotFound();
            }
            //Http Status code '201 Created'
            return CreatedAtAction("GetRoleById", new { Id = roleId }, roleToCreate);
        }

        // PUT Role
        [HttpPut(Name = "UpdateRole")]
        public IActionResult Update([FromBody] UpdateRoleDto role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var roleToUpdate = new UpdateRoleDto
            {
                Id = role.Id,
                RoleName = role.RoleName,
                RowVersion = role.RowVersion
            };

            var roleId = _roleCommand.UpdateRole(roleToUpdate);

            if (roleId == Guid.Empty)
            {
                return NotFound();
            }

            return CreatedAtAction("GetRoleById", new { Id = roleId }, roleToUpdate);
        }

        // DELETE Role/5
        [HttpDelete("{id}")]
        public void DeleteRole(int id)
        {
            //TODO: INA: DeleteRole to be implemented
        }
    }
}
