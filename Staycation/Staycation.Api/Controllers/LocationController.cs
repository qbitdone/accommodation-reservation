using Microsoft.AspNetCore.Mvc;
using Staycation.Api.Models;
using Staycation.Api.Services;

namespace Staycation.Api.Controllers
{
    [Route("api/location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        public LocationService _locationService;

        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpPost]
        public IActionResult AddLocation([FromBody] LocationViewModel location)
        {
            _locationService.AddLocation(location);
            return Ok(location);
        }

        [HttpGet]
        public IActionResult GetAllLocations()
        {
         var _allLocations = _locationService.GetAllLocations();
         return Ok(_allLocations);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLocationById(int id, [FromBody] LocationViewModel location)
        {
            var updatedLocation = _locationService.UpdateLocationById(id, location);
            if (updatedLocation == null)
            {
                return NotFound($"Location with id {id} does not exists");
            }
            return Ok($"You have successfully updated location with id {id}"); 
        }
    }
}
