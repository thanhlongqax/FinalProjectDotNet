using Gimji.DTO;
using Gimji.Models;
using Gimji.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gimji.Controllers
{
    [Route("api/role")]
    [ApiController]
    [Authorize(Policy ="admin")]
    public class RoleController : ControllerBase
    {
        private RoleRepository roleRepository;
        public RoleController(RoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            return Ok(await roleRepository.GetAllRole());
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            return Ok(await roleRepository.GetRoleById(id));
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleDTO roleDTO)
        {
            await roleRepository.AddRole(roleDTO);
            return Ok();
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] RoleDTO roleDTO)
        {
            await roleRepository.UpdateRole(id,roleDTO);
            return Ok();
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await roleRepository.DeleteRole(id);
            return Ok();
        }
    }
}
