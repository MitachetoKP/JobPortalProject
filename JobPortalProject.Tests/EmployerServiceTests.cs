using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Services;
using JobPortalProject.Infrastructure.Data;
using JobPortalProject.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobPortalProject.Tests
{
    [TestFixture]
    public class EmployerServiceTests
    {
        private JobPortalDbContext context;
        private IEmployerService employerService;

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
        }

        [Test]
        public async Task CreateEmployerAsync_SucccesfullyCreatesAnEmployer()
        {
            var employee = new Employee() { Id = "id", PhoneNumber = "1234567890" };

            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();

            await employerService.CreateEmployerAsync(employee.Id, employee.PhoneNumber);

            Assert.That(context.Employers.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task CreateEmployerAsync_DoesNotCreateAnEmployer_InvalidData()
        {
            var employee = new Employee() { Id = "", PhoneNumber = "" };

            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();

            await employerService.CreateEmployerAsync(employee.Id, employee.PhoneNumber);

            Assert.Throws<ArgumentException>(delegate { throw new ArgumentException(); });
        }

        [Test]
        public async Task CreateOfferAsync_SucccesfullyCreatesAnOffer()
        {
            await employerService.CreateOfferAsync("", "", 0, 1, 1, 1, 1);

            Assert.That(context.Offers.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task DeleteAsync_SuccesfullyDeletesAnOffer()
        {
            await employerService.CreateOfferAsync("", "", 0, 1, 1, 1, 1);

            await employerService.DeleteAsync(1);

            Assert.That(context.Offers.Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task EditOfferAsync_SuccesfullyEditsAnOffer()
        {
            await employerService.CreateOfferAsync("oldTitle", "oldDescription", 0, 1, 1, 1, 1);

            await employerService.EditOfferAsync(1, "newTitle", "newDescription", 1000, 2, 2, 2);

            var offer = await context.Offers
                .FirstAsync(o => o.Id == 1);

            Assert.That(offer.Title, Is.EqualTo("newTitle"));
            Assert.That(offer.Description, Is.EqualTo("newDescription"));
            Assert.That(offer.Salary, Is.EqualTo(1000.0));
            Assert.That(offer.LocationId, Is.EqualTo(2));
            Assert.That(offer.SeniorityId, Is.EqualTo(2));
            Assert.That(offer.CategoryId, Is.EqualTo(2));
        }

        [Test]
        public async Task EmployeeWithPhoneNumberExists_EmployerExists()
        {
            var employee = new Employee() { Id = "id", PhoneNumber = "1234567890" };

            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();

            await employerService.CreateEmployerAsync(employee.Id, employee.PhoneNumber);

            var exists = await employerService.EmployeeWithPhoneNumberExists(employee.PhoneNumber);

            Assert.That(exists, Is.True);
        }

        [Test]
        public async Task EmployeeWithPhoneNumberExists_EmployerDoesNotExist()
        {
            var employee = new Employee() { Id = "id", PhoneNumber = "1234567890" };

            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();

            await employerService.CreateEmployerAsync(employee.Id, employee.PhoneNumber);

            var exists = await employerService.EmployeeWithPhoneNumberExists("0987654321");

            Assert.That(exists, Is.False);
        }

        [Test]
        public async Task ExistsById_RetunsTrue()
        {
            var employee = new Employee() { Id = "id", PhoneNumber = "1234567890" };

            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();

            await employerService.CreateEmployerAsync(employee.Id, employee.PhoneNumber);

            var exists = await employerService.ExistsById(employee.Id);

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsById_RetunsFalse()
        {
            var exists = await employerService.ExistsById("");

            Assert.IsFalse(exists);
        }

        [Test]
        public async Task GetEmployerId_ReturnsTheEmployerID()
        {
            Employee employee = new Employee() { Id = "id", PhoneNumber = "1234567890" };

            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();

            await employerService.CreateEmployerAsync(employee.Id, employee.PhoneNumber);

            int id = await employerService.GetEmployerId(employee.Id);

            Assert.That(id, Is.EqualTo(1));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
