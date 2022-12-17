using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Services;
using JobPortalProject.Infrastructure.Data;
using JobPortalProject.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobPortalProject.Tests
{
    [TestFixture]
    public class OfferServiceTests
    {
        private JobPortalDbContext context;
        private IEmployerService employerService;
        private IOfferService offerService;

        [SetUp]
        public void SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<JobPortalDbContext>()
                .UseInMemoryDatabase("JobDb")
                .Options;

            context = new JobPortalDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            employerService = new EmployerService(context);
            offerService = new OfferService(context);
        }

        [Test]
        public async Task ApplyForOfferAsync_SuccesfullyApplies()
        {
            await context.Employees.AddAsync(new Employee()
            {
                Id = "employerId"
            });

            await context.SaveChangesAsync();

            await context.Employers.AddAsync(new Employer() { Id = 1, PhoneNumber = "14365786", UserId = "employerId" });

            await employerService.CreateOfferAsync("Title", "Description", 0, 1, 1, 1, 1);

            await context.Employees.AddAsync(new Employee()
            {
                Id = "employeeId"
            });

            await context.SaveChangesAsync();
            
            var isApplied = await offerService.IsApplied(1, "employeeId");

            await offerService.ApplyForOfferAsync(1, "employeeId");

            var offer = await context.Offers.FirstAsync();

            Assert.IsFalse(isApplied);
            Assert.That(offer.AppliedEmployees.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task ApplyForOfferAsync_AlreadyApplied()
        {
            await context.Employees.AddAsync(new Employee()
            {
                Id = "employerId"
            });

            await context.SaveChangesAsync();

            await context.Employers.AddAsync(new Employer() { Id = 1, PhoneNumber = "14365786", UserId = "employerId" });

            await employerService.CreateOfferAsync("Title", "Description", 0, 1, 1, 1, 1);

            await context.Employees.AddAsync(new Employee()
            {
                Id = "employeeId"
            });

            await context.SaveChangesAsync();

            await offerService.ApplyForOfferAsync(1, "employeeId");

            var offer = await context.Offers.FirstAsync();

            var isApplied = await offerService.IsApplied(1, "employeeId");

            Assert.That(isApplied, Is.True);
        }

        [Test]
        public async Task Exists_ReturnsTrue()
        {
            await employerService.CreateOfferAsync("oldTitle", "oldDescription", 0, 1, 1, 1, 1);

            var exists = await offerService.Exists(1);

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task Exists_ReturnsFalse()
        {
            var exists = await offerService.Exists(1);

            Assert.IsFalse(exists);
        }

        [Test]
        public async Task HasEmployerWithIdAsync_ReturnsTrue()
        {
            await context.Employees.AddAsync(new Employee() { Id = "id", PhoneNumber = "123456789" });

            await context.SaveChangesAsync();

            await employerService.CreateEmployerAsync("id", "123456789");

            await employerService.CreateOfferAsync("oldTitle", "oldDescription", 0, 1, 1, 1, 1);

            var hasEmployer = await offerService.HasEmployerWithIdAsync(1, "id");

            Assert.IsTrue(hasEmployer);
        }

        [Test]
        public async Task HasEmployerWithIdAsync_OfferIsNull_ReturnsFalse()
        {
            var hasEmployer = await offerService.HasEmployerWithIdAsync(1, "id");

            Assert.IsFalse(hasEmployer);
        }

        [Test]
        public async Task HasEmployerWithIdAsync_EmployerIsNull_ReturnsFalse()
        {
            await employerService.CreateOfferAsync("oldTitle", "oldDescription", 0, 1, 1, 1, 1);

            var hasEmployer = await offerService.HasEmployerWithIdAsync(1, "id");

            Assert.IsFalse(hasEmployer);
        }

       
    }
}
