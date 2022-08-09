using Staycation.Api.DatabaseContext;
using Staycation.Api.Models;

namespace Staycation.Api.Services
{
    public class LocationService
    {
        private AppDbContext _context;
        public LocationService (AppDbContext context)
        {
            _context = context;
        }

        public void AddLocation(LocationViewModel location)
        {
            var _location = new Location()
            {
                Name = location.Name,
                PostalCode = location.PostalCode
            };
            _context.Locations.Add(_location);
            _context.SaveChanges();
        }

        public List<LocationResponse> GetAllLocations()
        {
            var _allLocations = _context.Locations.Select(location => new LocationResponse()
            {
                Id = location.Id,
                Name = location.Name,
                PostalCode=location.PostalCode,
            }).ToList();
            return _allLocations;
        }

        public Location UpdateLocationById(int locationId, LocationViewModel location)
        {
            var _location = _context.Locations.FirstOrDefault(n => n.Id == locationId);
            if (_location != null)
            {
                _location.Name = location.Name;
                _location.PostalCode = location.PostalCode;

                _context.SaveChanges();
            }
            return _location;
        }

        public bool DeleteLocationById (int locationId)
        {
            var _location = _context.Locations.FirstOrDefault(n => n.Id == locationId);
            if (_location != null)
            {
                _context.Locations.Remove(_location);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
