using JobPortalProject.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortalProject.Infrastructure.Data.Configuration
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasData(CreateOffers());
        }

        private List<Offer> CreateOffers()
        {
            var offers = new List<Offer>();

            var offer = new Offer()
            {
                Id = 1,
                Title = "Junior C#",
                Description = "Junior C# developer. No experience required.",
                CreatedOn = DateTime.Now,
                Salary = 2000,
                CategoryId = 2,
                LocationId = 1,
                SeniorityId = 3,
                EmployerId = 2,
            };

            offers.Add(offer);

            offer = new Offer()
            {
                Id = 2,
                Title = "Java Senior",
                Description = "Senior Java developer. Must have 5+ years of experience in Java.",
                CreatedOn = DateTime.Parse("10/12/2022"),
                Salary = 5000,
                CategoryId = 1,
                LocationId = 2,
                SeniorityId = 1,
                EmployerId = 2,
            };

            offers.Add(offer);

            offer = new Offer()
            {
                Id = 3,
                Title = "C# Full-Stack Senior",
                Description = "Senior Java developer. Must have 6+ years of experience in C# and JS.",
                CreatedOn = DateTime.Parse("02/12/2022"),
                Salary = 6000,
                CategoryId = 2,
                LocationId = 3,
                SeniorityId = 1,
                EmployerId = 3,
            };

            offers.Add(offer);

            offer = new Offer()
            {
                Id = 4,
                Title = "Mid Level Python Developer",
                Description = "Back-End Python Developer with 2+ years of expirence.",
                CreatedOn = DateTime.Parse("09/12/2022"),
                Salary = 3500,
                CategoryId = 4,
                LocationId = 2,
                SeniorityId = 2,
                EmployerId = 3,
            };

            offers.Add(offer);

            offer = new Offer()
            {
                Id = 5,
                Title = "Senior JS Developer",
                Description = "Full-Stack Senior JS Developer. Must be expirienced in Node.Js and Angular/React.Js.",
                CreatedOn = DateTime.Parse("11/12/2022"),
                Salary = 5400,
                CategoryId = 3,
                LocationId = 1,
                SeniorityId = 1,
                EmployerId = 1,
            };

            offers.Add(offer);

            return offers;
        }
    }
}
