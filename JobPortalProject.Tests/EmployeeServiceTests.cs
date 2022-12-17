using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Models.UserModels;
using JobPortalProject.Core.Services;
using JobPortalProject.Infrastructure.Data;
using JobPortalProject.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobPortalProject.Tests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private JobPortalDbContext context;
        private IEmployeeService employeeService;

        [SetUp]
        public void SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<JobPortalDbContext>()
                .UseInMemoryDatabase("JobDb")
                .Options;

            context = new JobPortalDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            employeeService = new EmployeeService(context);
        }

        [Test]
        public async Task EditInfoAsync_ShouldEditUserInfo()
        {
            var employee = new Employee()
            {
                Id = "userId",
                UserName = "oldName",
                CV = "oldCV",
                Email = "oldEmail"
            };

            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();

            await employeeService.EditInfoAsync(employee.Id, "newName", "newEmail", "newCV");

            Assert.That(employee.UserName, Is.Not.EqualTo("oldName"));
            Assert.That(employee.Email, Is.Not.EqualTo("oldEmail"));
            Assert.That(employee.CV, Is.Not.EqualTo("oldCV"));
        }

        [Test]
        public async Task GetAllAsync_ReturnsAllUsers()
        {
            await context.Employees.AddRangeAsync(new List<Employee>()
            {
                new Employee() { Id = "first" },
                new Employee() { Id = "second" },
                new Employee() { Id = "third" }
            });

            await context.SaveChangesAsync();

            var count = context.Employees.Count();
            var users = await employeeService.GetAllAsync();

            Assert.That(users.Count(), Is.EqualTo(count));
        }

        [Test]
        public async Task GetUser_ShouldReturnUser()
        {
            await context.AddAsync(new Employee()
            {
                Id = "userId",
                UserName = "Name",
                Email = "Email",
            });

            await context.SaveChangesAsync();

            var employee = new UserViewModel()
            {
                Id = "userId",
                UserName = "Name",
                Email = "Email",
            };

            var user = await employeeService.GetUser(employee.Id);

            Assert.That(user, Is.Not.Null);
            Assert.That(user.Id, Is.EqualTo(employee.Id));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
