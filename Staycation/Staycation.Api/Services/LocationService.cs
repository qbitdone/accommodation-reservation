using Staycation.Api.DatabaseContext;

namespace Staycation.Api.Services
{
    public class LocationService
    {
        private AppDbContext _context;
        public LocationService (AppDbContext context)
        {
            _context = context;
        }
    }
}
