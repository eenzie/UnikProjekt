using Microsoft.AspNetCore.Mvc;
using UnikProjekt.Application.Commands;
using UnikProjekt.Application.Queries;
using UnikProjekt.Application.Queries.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnikProjekt.Api.Controller
{
    [Route("api/[controller]")]
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

        // GET: api/<RoleController>
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


        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RoleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
