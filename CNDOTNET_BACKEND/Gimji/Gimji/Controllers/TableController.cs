using Gimji.Models;
using Gimji.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gimji.Controllers
{
    [Route("api/table")]
    [ApiController]
    [Authorize(Policy ="admin")]
    public class TableController : ControllerBase
    {
        private RestaurantTableRepository restaurantTableRepository;
        public TableController(RestaurantTableRepository restaurantTableRepository)
        {
            this.restaurantTableRepository = restaurantTableRepository;
        }
        // GET: api/<TableController>
        [HttpGet]
        public async Task<IActionResult> GetTableAll()
        {
            return Ok(await restaurantTableRepository.GetAllRestaurantTable());
        }

        // GET api/<TableController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableById(int id)
        {
            return Ok(await restaurantTableRepository.GetRestaurantTableById(id));
        }

        // POST api/<TableController>
        [HttpPost]
        public async Task<IActionResult> CreateTable([FromBody] RestaurantTable Table)
        {
            await restaurantTableRepository.AddRestaurantTable(Table);
            return Ok();
        }

        // PUT api/<TableController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTable(int id, [FromBody] RestaurantTable Table)
        {
            await restaurantTableRepository.UpdateRestaurantTable(id, Table);
            return Ok();
        }

        // DELETE api/<TableController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            await restaurantTableRepository.DeleteRestaurantTable(id);
            return Ok();    
        }
    }
}
