using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staycation.Api.Data.Models;
using Staycation.Api.Data.Services;
using Staycation.Api.Models;
using Staycation.Api.Services;

namespace Staycation.Api.Controllers
{
    [Route("api/accommodation")]
    [ApiController]
    public class AccommodationController : ControllerBase
    {
        public AccommodationService _accommodationService;


        public AccommodationController(AccommodationService accommodationService, LocationService locationService)
        {
            _accommodationService = accommodationService;
        }

        [HttpPost]
        public IActionResult AddAccommodation([FromBody] AccommodationViewModel accommodation)
        {
            _accommodationService.AddAccommodation(accommodation); // add new accommodation to the database
            return Ok(accommodation); // returns Ok and accommodation that has been added to the database
        }

        [HttpGet]
        public IActionResult GetAllAccommodations()
        {
            var allAccommodations = _accommodationService.GetAllAccommodationsv2(); // get all accommodations from database
            return Ok(allAccommodations); // returns Ok and list of all the accommodations from the database
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAccommodationById(int id, [FromBody] AccommodationViewModel accommodation)
        {
            var updatedAccommodation = _accommodationService.UpdateAccommodationsById(id, accommodation); // call UpdateAccommodationsById method and save result to updateAccommodation variable
            if (updatedAccommodation == null)
            {
                return NotFound($"Accommodation with id {id} does not exists"); // if accommodation is not found in database, return error code with message
            }
            return Ok($"You have successfully updated accommodation with id {id}"); // if accommodation is updated successfully, return Ok with message
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAccommodationById(int id)
        {
            bool isSuccessfull = _accommodationService.DeleteAccommodationById(id); // call DeleteAccommodationById method and save result to isSuccessfull
            if (!isSuccessfull)
            {
                return NotFound($"Accommodation with id {id} does not exists"); // if accommodation is not found in database, return error code with message
            }
            return Ok($"You have successfully deleted accommodation with id {id}"); // if accommodation is deleted sucessfully, return Ok with message
        }
    }
}
