using Staycation.Api.DatabaseContext;
using Staycation.Api.Models;

namespace Staycation.Api.Services
{
    public class ReservationService
    {
        private AppDbContext _context;

        public ReservationService(AppDbContext context)
        {
            _context = context;
        }

        public void AddReservation(ReservationViewModel reservation)
        {
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
        }
    }
}
