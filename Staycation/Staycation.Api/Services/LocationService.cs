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

        public List<Location> GetAllLocations()
        {
            return _context.Locations.ToList();
        }
    }
}
