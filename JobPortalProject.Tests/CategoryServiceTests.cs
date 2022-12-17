using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Services;
using JobPortalProject.Infrastructure.Data;
using JobPortalProject.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobPortalProject.Tests
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private JobPortalDbContext context;
        private ICategoryService categoryService;

        [SetUp]
        public void SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<JobPortalDbContext>()
                .UseInMemoryDatabase("JobDb")
                .Options;

            context = new JobPortalDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
            categoryService = new CategoryService(context);
        }

        [Test]
        public async Task CategoryExists_ReturnTrue()
        {
            await context.Categories.AddRangeAsync(new List<Category>()
            {
                new Category() { Id = 1, Title = ""}
            });

            await context.SaveChangesAsync();

            var exists = await categoryService.CategoryExists(1);

            Assert.IsTrue(exists);
        }

        [Test]
        public async Task CategoryExists_ReturnFalse()
        {
            await context.Categories.AddRangeAsync(new List<Category>()
            {
                new Category() { Id = 1, Title = ""}
            });

            await context.SaveChangesAsync();

            var exists = await categoryService.CategoryExists(2);

            Assert.IsFalse(exists);
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllCategories()
        {
            await context.Categories.AddRangeAsync(new List<Category>()
            {
                new Category() { Id = 1, Title = ""},
                new Category() { Id = 2, Title = ""},
                new Category() { Id = 3, Title = ""}
            });

            var categories = await categoryService.GetAllAsync();
            var count = context.Categories.Count();

            Assert.That(categories.Count(), Is.EqualTo(count));
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnNoCategories()
        {

            var categories = await categoryService.GetAllAsync();
            var count = context.Categories.Count();

            Assert.AreEqual(count, categories.Count());
        }

        [Test]
        public async Task GetCategoryIdAsync_ShouldReturnCategoryId()
        {
            await context.Categories.AddRangeAsync(new List<Category>()
            {
                new Category() { Id = 1, Title = ""}
            });

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

            var id = await categoryService.GetCategoryIdAsync(offer.Id);

            Assert.AreEqual(1, id);
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
