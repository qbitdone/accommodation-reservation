using Staycation.Api.Data.Models;
using Staycation.Api.DatabaseContext;
using Staycation.Api.Exceptions;
using Staycation.Api.Models;
using Staycation.Api.Pagination;

namespace Staycation.Api.Services
{
    public class ReservationService
    {
        private AppDbContext _context;

        public ReservationService(AppDbContext context)
        {
            _context = context;
        }

        public Reservation AddReservation(ReservationViewModel reservation)
        {
            if (!AccommodationExists(reservation.AccommodationId))
            {
                throw new ReservationNotPossibleException("Accommodation with that id does not exists", reservation.AccommodationId);
            }
                var _reservation = new Reservation()
                {
                    Email = reservation.Email,
                    CheckIn = reservation.CheckIn,
                    CheckOut = reservation.CheckOut,
                    PersonCount = reservation.PersonCount,
                    Confirmed = reservation.Confirmed,
                    AccommodationId = reservation.AccommodationId
                };

                _context.Add(_reservation);
                _context.SaveChanges();

                return _reservation;
        }

        public List<ReservationDTO> GetAllReservations(string sortBy, string filterBy, int? pageNumber)
        {
            var allReservations = GetConvertReservationToReservationDTO();

            // Sorting
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "email_desc":
                        allReservations = allReservations.OrderByDescending(n => n.Email).ToList();
                        break;
                    case "email_acs":
                        allReservations = allReservations.OrderBy(n => n.Email).ToList();
                        break;
                    case "check_in_desc":
                        allReservations = allReservations.OrderByDescending(n => n.CheckIn).ToList();
                        break;
                    case "check_in_acs":
                        allReservations = allReservations.OrderBy(n => n.CheckIn).ToList();
                        break;
                    default:
                        break;
                }
            }

            // Filtering
            if (!string.IsNullOrEmpty(filterBy))
            {
                allReservations = allReservations.Where(n => n.Email.Contains(filterBy)).ToList();
            }

            // Paging
            int pageSize = 5;
            allReservations = PaginatedList<ReservationDTO>.Create(allReservations.AsQueryable(), pageNumber ?? 1, pageSize);
            return allReservations;
            
        }

        public bool UpdateReservationById(ReservationViewModel reservation, int reservationId)
        {
            if (!AccommodationExists(reservation.AccommodationId))
            {
                throw new ReservationNotPossibleException("Accommodation with that id does not exists", reservation.AccommodationId);
            }
            var _reservation = _context.Reservations.FirstOrDefault(n => n.Id == reservationId);
            if (_reservation != null)
            {
                _reservation.Email = reservation.Email;
                _reservation.CheckIn = reservation.CheckIn;
                _reservation.CheckOut = reservation.CheckOut;
                _reservation.PersonCount = reservation.PersonCount;
                _reservation.Confirmed = reservation.Confirmed;
                _reservation.AccommodationId = reservation.AccommodationId;

                _context.SaveChanges();

                return true;
            }
            return false;
        }

        public bool DeleteReservationById(int reservationId)
        {
            var _reservation = _context.Reservations.FirstOrDefault(n => n.Id == reservationId);
            if (_reservation != null)
            {
                _context.Reservations.Remove(_reservation);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AccommodationExists(int accommodationId)
        {
            var _accommodation = _context.Accommodations.FirstOrDefault(n => n.Id == accommodationId);
            if (_accommodation != null)
            {
                return true;
            }
            return false;
        }

        public List<ReservationDTO> GetConvertReservationToReservationDTO()
        {
            var _reservations = _context.Reservations.Select(reservation => new ReservationDTO()
            {
                Id = reservation.Id,
                Email = reservation.Email,
                CheckIn = reservation.CheckIn,
                CheckOut = reservation.CheckOut,
                PersonCount = reservation.PersonCount,
                Confirmed = reservation.Confirmed,
                Accommodation = new AccommodationDTO()
                {
                    Id = reservation.Accommodation.Id,
                    Title = reservation.Accommodation.Title,
                    Subtitle = reservation.Accommodation.Subtitle,
                    Description = reservation.Accommodation.Description,
                    Type = reservation.Accommodation.Type,
                    Categorization = reservation.Accommodation.Categorization,
                    PersonCount = reservation.Accommodation.PersonCount,
                    ImageUrl = reservation.Accommodation.ImageUrl,
                    FreeCancelation = reservation.Accommodation.FreeCancelation,
                    Price = reservation.Accommodation.Price,
                    Location = new LocationDTO()
                    {
                        Id = reservation.Accommodation.Location.Id,
                        Name = reservation.Accommodation.Location.Name,
                        PostalCode = reservation.Accommodation.Location.PostalCode,
                        ImageUrl = reservation.Accommodation.Location.ImageUrl
                    }
                }
            }).ToList();

            return _reservations;
        }
    }
}
