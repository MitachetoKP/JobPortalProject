using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Services;
using JobPortalProject.Infrastructure.Data;
using JobPortalProject.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobPortalProject.Tests
{
    [TestFixture]
    public class SeniorityServiceTests
    {
        private JobPortalDbContext context;
        private ISeniorityService seniorityService;

        [SetUp]
        public void SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<JobPortalDbContext>()
                .UseInMemoryDatabase("JobDb")
                .Options;

            context = new JobPortalDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            seniorityService = new SeniorityService(context);
        }

        [Test]
        public async Task Seniorityxists_ReturnTrue()
        {
            await context.Seniorities.AddAsync(new Seniority() { Id = 1, Level = "" });

            await context.SaveChangesAsync();

            var exists = await seniorityService.SeniorityExists(1);

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task SeniorityExists_ReturnFalse()
        {
            await context.Seniorities.AddAsync(new Seniority() { Id = 1, Level = "" });

            await context.SaveChangesAsync();

            var exists = await seniorityService.SeniorityExists(2);

            Assert.IsFalse(exists);
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllSeniorities()
        {
            await context.Seniorities.AddRangeAsync(new List<Seniority>()
            {
                new Seniority() { Id = 1, Level = ""},
                new Seniority() { Id = 2, Level = ""},
                new Seniority() { Id = 3, Level = ""}
            });

            var seniorities = await seniorityService.GetAllAsync();
            var count = context.Locations.Count();

            Assert.That(seniorities.Count(), Is.EqualTo(count));
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnNoSeniorities()
        {

            var seniorities = await seniorityService.GetAllAsync();
            var count = context.Seniorities.Count();

            Assert.AreEqual(count, seniorities.Count());
        }

        [Test]
        public async Task GetSeniorityIdAsync_ShouldReturnSeniorityId()
        {
            await context.Seniorities.AddAsync(new Seniority() { Id = 1, Level = "" });

            var offer = new Offer()
            {
                Id = 1,
                Title = "",
                Description = "",
                Salary = 0,
                CreatedOn = DateTime.Now,
                EmployerId = 1,
                LocationId = 1,
                CategoryId = 1,
                SeniorityId = 1
            };

            await context.Offers.AddAsync(offer);

            await context.SaveChangesAsync();

            var id = await seniorityService.GetSeniorityIdAsync(offer.Id);

            Assert.AreEqual(1, id);
        }
    }
}
