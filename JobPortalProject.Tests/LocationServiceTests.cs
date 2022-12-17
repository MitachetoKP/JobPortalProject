using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Services;
using JobPortalProject.Infrastructure.Data;
using JobPortalProject.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobPortalProject.Tests
{
    [TestFixture]
    public class LocationServiceTests
    {
        private JobPortalDbContext context;
        private ILocationService locationService;

        [SetUp]
        public void SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<JobPortalDbContext>()
                .UseInMemoryDatabase("JobDb")
                .Options;

            context = new JobPortalDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            locationService = new LocationService(context);
        }

        [Test]
        public async Task LocationExists_ReturnTrue()
        {
            await context.Locations.AddAsync(new Location() { Id = 1, Name = "" });

            await context.SaveChangesAsync();

            var exists = await locationService.LocationExists(1);

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task LocationExists_ReturnFalse()
        {
            await context.Locations.AddAsync(new Location() { Id = 1, Name = "" });

            await context.SaveChangesAsync();

            var exists = await locationService.LocationExists(2);

            Assert.IsFalse(exists);
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllLocations()
        {
            await context.Locations.AddRangeAsync(new List<Location>()
            {
                new Location() { Id = 1, Name = ""},
                new Location() { Id = 2, Name = ""},
                new Location() { Id = 3, Name = ""}
            });

            var locations = await locationService.GetAllAsync();
            var count = context.Locations.Count();

            Assert.That(locations.Count(), Is.EqualTo(count));
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnNoLocations()
        {

            var locations = await locationService.GetAllAsync();
            var count = context.Locations.Count();

            Assert.AreEqual(count, locations.Count());
        }

        [Test]
        public async Task GetLocationIdAsync_ShouldReturnLocationId()
        {
            await context.Locations.AddAsync(new Location() { Id = 1, Name = "" });

            var offer = new Offer()
            {
                Id = 1,
                Title = "",
                Description = "",
                Salary = 0,
                CreatedOn = DateTime.Now,
                EmployerId = 1,
                LocationId = 1,
                CategoryId = 1
            };

            await context.Offers.AddAsync(offer);

            await context.SaveChangesAsync();

            var id = await locationService.GetLocationIdAsync(offer.Id);

            Assert.AreEqual(1, id);
        }
    }
}
