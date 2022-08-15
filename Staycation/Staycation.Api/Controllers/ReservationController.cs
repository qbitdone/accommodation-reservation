using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staycation.Api.Exceptions;
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
            try
            {
                _reservationService.AddReservation(reservation);
                return Created(nameof(AddReservation), reservation);
            }
            catch (ReservationNotPossibleException ex)
            {
                return BadRequest($"{ex.Message} AccommodationId: {ex.AccommodationId}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllReservations(string? sortBy, string? filterBy)
        {
            try
            {
                var allReservations = _reservationService.GetAllReservations(sortBy, filterBy);
                if (allReservations == null || (!allReservations.Any()))
                {
                    return NotFound();
                }
                return Ok(allReservations);
            }
            catch (Exception)
            {
                return BadRequest("Sorry we could not fetch the reservations");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReservationById(int id, [FromBody] ReservationViewModel reservation)
        {
            try
            {
                bool isSucessfull = _reservationService.UpdateReservationById(reservation, id);
                if (!isSucessfull)
                {
                    return NotFound($"Reservation with {id} does not exists");
                }
                return Accepted($"You have successfully updated reservation with id {id}");
            }
            catch (ReservationNotPossibleException ex)
            {
                return BadRequest($"{ex.Message} AccommodationId: {ex.AccommodationId}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }        
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
