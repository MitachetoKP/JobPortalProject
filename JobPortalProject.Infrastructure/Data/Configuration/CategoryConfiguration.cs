using JobPortalProject.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortalProject.Infrastructure.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            var categories = new List<Category>();

            //Java
            var category = new Category()
            {
                Id = 1,
                Title = "Java"
            };

            categories.Add(category);

            //.NET
            category = new Category()
            {
                Id = 2,
                Title = ".NET"
            };

            categories.Add(category);

            //Javascript
            category = new Category()
            {
                Id = 3,
                Title = "Javascript"
            };

            categories.Add(category);

            //Python
            category = new Category()
            {
                Id = 4,
                Title = "Python"
            };

            categories.Add(category);

            return categories;
        }
    }
}
