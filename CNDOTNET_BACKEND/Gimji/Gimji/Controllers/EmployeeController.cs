using Gimji.DTO;
using Gimji.Models;
using Gimji.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gimji.Controllers
{
    [Route("api/employee")]
    [ApiController]
    //[Authorize(Policy = "authenticated")]
    [AllowAnonymous]
    public class EmployeeController : ControllerBase
    {
        private EmployeeRepository employeeRepository;
        public EmployeeController(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> GetEmployeeAll()
        {
            return Ok(await employeeRepository.GetAllEmmployee());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            return Ok(await employeeRepository.GetEmployeeById(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            await employeeRepository.AddEmployee(employeeDTO);
            return Ok();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDTO employeeDTO)
        {
            await employeeRepository.UpdateEmployee(id, employeeDTO);
            return Ok();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await employeeRepository.DeleteEmployee(id);
            return Ok();
        }
    }
}
