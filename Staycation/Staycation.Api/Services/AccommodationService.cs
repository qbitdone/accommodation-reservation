using Staycation.Api.Data.Models;
using Staycation.Api.DatabaseContext;
using Staycation.Api.Models;

namespace Staycation.Api.Data.Services
{
    public class AccommodationService
    {
        private AppDbContext _context;

        public AccommodationService(AppDbContext context)
        {
            _context = context;
        }

        // This method takes accommodation object and adds it to the database
        public void AddAccommodation(AccommodationViewModel accommodation)
        {
            var _accommodation = new Accommodation()
            {
                Title = accommodation.Title,
                Subtitle = accommodation.Subtitle,
                Description = accommodation.Description,
                Type = accommodation.Type,
                Categorization = accommodation.Categorization,
                PersonCount = accommodation.PersonCount,
                ImageUrl = accommodation.ImageUrl,
                FreeCancelation = accommodation.FreeCancelation,
                Price = accommodation.Price,
                LocationId = accommodation.LocationId
            };

            _context.Accommodations.Add(_accommodation);
            _context.SaveChanges();

        }

        public List<AccommodationResponse> GetAllAccommodations()
        {
            var _accommodations = _context.Accommodations.Select(accommodation => new AccommodationResponse()
            {
                Id = accommodation.Id,
                Title = accommodation.Title,
                Subtitle = accommodation.Subtitle,
                Description = accommodation.Description,
                Type = accommodation.Type,
                Categorization = accommodation.Categorization,
                PersonCount = accommodation.PersonCount,
                ImageUrl = accommodation.ImageUrl,
                FreeCancelation = accommodation.FreeCancelation,
                Price = accommodation.Price,
                Location = new LocationResponse()
                {
                    Id = accommodation.Location.Id,
                    Name = accommodation.Location.Name,
                    PostalCode = accommodation.Location.PostalCode,
                    ImageUrl = accommodation.Location.ImageUrl
                }
            }).ToList();
            return _accommodations;
        }

        // This method updates the accommodation for given id and accommodation in the database
        public Accommodation UpdateAccommodationsById(int accommodationId, AccommodationViewModel accommodation)
        {
            var _accommodation = _context.Accommodations.FirstOrDefault(n => n.Id == accommodationId);
            if (_accommodation != null)
            {
                _accommodation.Title = accommodation.Title;
                _accommodation.Subtitle = accommodation.Subtitle;
                _accommodation.Description = accommodation.Description;
                _accommodation.Type = accommodation.Type;
                _accommodation.Categorization = accommodation.Categorization;
                _accommodation.PersonCount = accommodation.PersonCount;
                _accommodation.ImageUrl = accommodation.ImageUrl;
                _accommodation.FreeCancelation = accommodation.FreeCancelation;
                _accommodation.Price = accommodation.Price;
                _accommodation.LocationId = accommodation.LocationId;

                _context.SaveChanges();
            }
            return _accommodation;
        }

        // This method deletes accommodation for given id from the database
        public bool DeleteAccommodationById(int accommodationId)
        {
            var _accommodation = _context.Accommodations.FirstOrDefault(n => n.Id == accommodationId);
            if (_accommodation != null)
            {
                _context.Accommodations.Remove(_accommodation);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<AccommodationResponse> GetAccommodationRecommedation()
        {
            return _context.Accommodations.Select(accommodation => new AccommodationResponse()
            {
                Id = accommodation.Id,
                Title = accommodation.Title,
                Subtitle = accommodation.Subtitle,
                Description = accommodation.Description,
                Type = accommodation.Type,
                Categorization = accommodation.Categorization,
                PersonCount = accommodation.PersonCount,
                ImageUrl = accommodation.ImageUrl,
                FreeCancelation = accommodation.FreeCancelation,
                Price = accommodation.Price,
                Location = new LocationResponse()
                {
                    Id = accommodation.Location.Id,
                    Name = accommodation.Location.Name,
                    PostalCode = accommodation.Location.PostalCode,
                    ImageUrl = accommodation.Location.ImageUrl
                }
            }).ToList().OrderBy(arg => Guid.NewGuid()).Take(10).ToList();
        }

        public List<AccommodationResponse> GetAllAccommodationsForLocation(int locationId)
        {
            var _accommodations = _context.Accommodations.Select(accommodation => new AccommodationResponse()
            {
                Id = accommodation.Id,
                Title = accommodation.Title,
                Subtitle = accommodation.Subtitle,
                Description = accommodation.Description,
                Type = accommodation.Type,
                Categorization = accommodation.Categorization,
                PersonCount = accommodation.PersonCount,
                ImageUrl = accommodation.ImageUrl,
                FreeCancelation = accommodation.FreeCancelation,
                Price = accommodation.Price,
                Location = new LocationResponse()
                {
                    Id = accommodation.Location.Id,
                    Name = accommodation.Location.Name,
                    PostalCode = accommodation.Location.PostalCode,
                    ImageUrl = accommodation.Location.ImageUrl
                }
            }).ToList().Where(n => n.Location.Id == locationId).ToList();

            return _accommodations;
        }
    }
}
