using Gimji.Models;
using Gimji.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gimji.Controllers
{
    [Route("api/customer")]
    [ApiController]
    //[Authorize]
    [AllowAnonymous]
    public class CustomerController : ControllerBase
    {
        private CustomerRepository customerRepository;
        public CustomerController(CustomerRepository customerRepository) 
        {
            this.customerRepository = customerRepository;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> GetCustomerAll()
        {
            return Ok( await customerRepository.GetAllCustomer()); 
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            return Ok(await customerRepository.GetCustomerById(id));
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] customer customer)
        {
            await customerRepository.AddCustomer(customer);
            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] customer customer)
        {
            await customerRepository.UpdateCustomer(id, customer);
            return Ok();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await customerRepository.DeleteCustomer(id);
            return Ok();
        }
    }
}
