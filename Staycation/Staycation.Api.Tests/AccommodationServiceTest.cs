using Microsoft.EntityFrameworkCore;
using Staycation.Api.Data.Models;
using Staycation.Api.Data.Services;
using Staycation.Api.DatabaseContext;
using Staycation.Api.Models;
using Staycation.Api.Services;

namespace Staycation.Api.Tests
{
    public class AccommodationServiceTest
    {
        private static DbContextOptions<AppDbContext> dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "accommodations-dbTest")
            .Options;

        AppDbContext context;

        AccommodationService accommodationService;
        LocationService locationService;
        ReservationService reservationService;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new AppDbContext(dbContextOptions);
            context.Database.EnsureCreated();

            InsertAccommodations();
            InsertLocations();
            InsertReservations();

            accommodationService = new AccommodationService(context);
            locationService = new LocationService(context);
            reservationService = new ReservationService(context);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        [Test, Order(1)]
        public void GetAllAccommodations()
        {
            var accommodations = accommodationService.GetAllAccommodations();

            Assert.AreEqual(3, accommodations.Count);
        }

        [Test, Order(2)]
        public void GetAllLocations()
        {
            var locations = locationService.GetAllLocations();
            Assert.AreEqual(3, locations.Count);
        }

        [Test, Order(3)]
        public void GetAllReservations()
        {
            var locations = reservationService.GetAllReservations();
            Assert.AreEqual(3, locations.Count);
        }

        [Test, Order(4)]
        public void GetAllAccommodationsForLocation()
        {
            var accommodations = accommodationService.GetAllAccommodationsForLocation(1);
            Assert.AreEqual(2, accommodations.Count);
        }

        private void InsertAccommodations()
        {
            var accommodations = new List<Accommodation>
            {
                new Accommodation()
                {
                    Id = 1,
                    Title = "Title1",
                    Subtitle = "Subtitle1",
                    Description = "Description1",
                    Type = "Room",
                    Categorization = 2,
                    PersonCount = 2,
                    ImageUrl = "http",
                    FreeCancelation = false,
                    Price = 5,
                    LocationId = 1
                },
                new Accommodation()
                {
                    Id = 2,
                    Title = "Title1",
                    Subtitle = "Subtitle1",
                    Description = "Description1",
                    Type = "Room",
                    Categorization = 2,
                    PersonCount = 2,
                    ImageUrl = "http",
                    FreeCancelation = false,
                    Price = 5,
                    LocationId = 1
                },
                new Accommodation()
                {
                    Id = 3,
                    Title = "Title1",
                    Subtitle = "Subtitle1",
                    Description = "Description1",
                    Type = "Room",
                    Categorization = 2,
                    PersonCount = 2,
                    ImageUrl = "http",
                    FreeCancelation = false,
                    Price = 5,
                    LocationId = 2
                }
            };
            context.Accommodations.AddRange(accommodations);
            context.SaveChanges();
        }

        private void InsertLocations()
        {
            var locations = new List<Location>()
            {
                new Location()
                {
                    Id = 1,
                    Name = "Test",
                    PostalCode = "3000",
                    ImageUrl = "http"
                },
                new Location()
                {
                    Id = 2,
                    Name = "Test2",
                    PostalCode = "3000",
                    ImageUrl = "http"
                },
                new Location()
                {
                    Id = 3,
                    Name = "Test3",
                    PostalCode = "3000",
                    ImageUrl = "http"
                },
            };

            context.Locations.AddRange(locations);
            context.SaveChanges();
        }

        private void InsertReservations()
        {
            var reservations = new List<Reservation>()
            {
                new Reservation()
                {
                    Id = 1,
                    Email = "first@email.com",
                    CheckIn = DateTime.Now,
                    CheckOut = DateTime.Now,
                    PersonCount = 5,
                    Confirmed = false,
                    AccommodationId = 1
                },
                new Reservation()
                {
                    Id = 2,
                    Email = "second@email.com",
                    CheckIn = DateTime.Now,
                    CheckOut = DateTime.Now,
                    PersonCount = 5,
                    Confirmed = false,
                    AccommodationId = 2
                },
                new Reservation()
                {
                    Id = 3,
                    Email = "third@email.com",
                    CheckIn = DateTime.Now,
                    CheckOut = DateTime.Now,
                    PersonCount = 5,
                    Confirmed = false,
                    AccommodationId = 3
                }
            };

            context.Reservations.AddRange(reservations);
            context.SaveChanges();
        }
    }
}