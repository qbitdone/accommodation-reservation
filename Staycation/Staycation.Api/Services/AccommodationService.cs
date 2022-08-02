using Staycation.Api.Data.Models;
using Staycation.Api.DatabaseContext;

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
                Price = accommodation.Price
            };

            _context.Accommodations.Add(_accommodation);
            _context.SaveChanges();

        }

        // This method returns list of all the accommodations from the database
        public List<Accommodation> GetAllAccommodations()
        {
            return _context.Accommodations.ToList();
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
    }
}
