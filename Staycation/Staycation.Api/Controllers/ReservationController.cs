using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staycation.Api.Models;
using Staycation.Api.Services;

namespace Staycation.Api.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        public ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public IActionResult AddReservation([FromBody] ReservationViewModel reservation)
        {
            var isSucessfull = _reservationService.AddReservation(reservation);
            if (!isSucessfull)
            {
                return BadRequest(); 
            }
            return Created(nameof(AddReservation), reservation);
        }

        [HttpGet]
        public IActionResult GetAllReservations()
        {
            var _allReservations = _reservationService.GetAllReservations();
            if (_allReservations == null || (!_allReservations.Any()))
            {
                return NotFound();
            }
            return Ok(_allReservations);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReservationById(int id, [FromBody] ReservationViewModel reservation)
        {
            var isSuccessfull = _reservationService.UpdateReservationById(reservation, id);
            if (!isSuccessfull)
            {
                return NotFound($"Reservation with id {id} does not exists");
            }
            return Accepted($"You have successfully updated reservation with id {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLocationById(int id)
        {
            bool isSuccessfull = _reservationService.DeleteReservationById(id);
            if (!isSuccessfull)
            {
                return NotFound($"Reservation with id {id} does not exists");
            }
            return Accepted($"You have successfully deleted reservation with id {id}");
        }
    }
}
