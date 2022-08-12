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

        [OneTimeSetUp]
        public void Setup()
        {
            context = new AppDbContext(dbContextOptions);
            context.Database.EnsureCreated();

            InsertAccommodations();
            InsertLocations();

            accommodationService = new AccommodationService(context);
            locationService = new LocationService(context);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public void GetAllAccommodations()
        {
            var accommodations = accommodationService.GetAllAccommodations();

            Assert.AreEqual(3, accommodations.Count);
        }

        [Test]
        public void GetAllLocations()
        {
            var locations = locationService.GetAllLocations();
            Assert.AreEqual(3, locations.Count);
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
                    LocationId = 1
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
    }
}