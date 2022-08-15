﻿using Staycation.Api.Data.Models;
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

        public bool AddReservation(ReservationViewModel reservation)
        {
            try
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

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ReservationDTO> GetAllReservations()
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

        public bool UpdateReservationById(ReservationViewModel reservation, int reservationId)
        {
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
    }
}
