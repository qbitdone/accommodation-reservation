using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staycation.Api.Models;
using Staycation.Api.Services;

namespace Staycation.Api.Controllers
{
    [Route("api/reservation")]
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
            _reservationService.AddReservation(reservation);
            return Ok(reservation);
        }

        [HttpGet]
        public IActionResult GetAllReservations()
        {
            var _allReservations = _reservationService.GetAllReservations();
            return Ok(_allReservations);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReservationById(int id, [FromBody] ReservationViewModel reservation)
        {
            var updatedReservation = _reservationService.UpdateReservationById(reservation, id);
            if (updatedReservation == null)
            {
                return NotFound($"Reservation with id {id} does not exists");
            }
            return Ok($"You have successfully updated reservation with id {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLocationById(int id)
        {
            bool isSuccessfull = _reservationService.DeleteReservationById(id);
            if (!isSuccessfull)
            {
                return NotFound($"Reservation with id {id} does not exists");
            }
            return Ok($"You have successfully deleted reservation with id {id}");
        }
    }
}
