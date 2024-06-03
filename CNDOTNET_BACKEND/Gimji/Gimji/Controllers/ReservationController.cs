using Gimji.DTO;
using Gimji.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gimji.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    [AllowAnonymous]
    public class ReservationController : ControllerBase
    {
        private ReservationRepository reservationRepository;
        public ReservationController(ReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }
        // GET: api/<ReservationController>
        [HttpGet]
        public async Task<IActionResult> GetReservationAll()
        {
            return Ok(await reservationRepository.GetAllReservation());
        }

        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(int id)
        {
            return Ok(await reservationRepository.GetReservationById(id));
        }

        // POST api/<ReservationController>
        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationDTO reservationDTO)
        {
            await reservationRepository.AddReservation(reservationDTO);
            return Ok();
        }
        [Authorize(Policy = "admin")]
        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, [FromBody] ReservationDTO reservationDTO)
        {
            await reservationRepository.UpdateReservation(id,reservationDTO);
            return Ok();
        }

        // DELETE api/<ReservationController>/5
        [Authorize(Policy ="admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            await reservationRepository.DeleteReservation(id);
            return Ok();
        }
    }
}
