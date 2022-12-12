using JobPortalProject.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortalProject.Infrastructure.Data.Configuration
{
    public class SeniorityConfiguration : IEntityTypeConfiguration<Seniority>
    {
        public void Configure(EntityTypeBuilder<Seniority> builder)
        {
            builder.HasData(CreateSeniorities());
        }

        private List<Seniority> CreateSeniorities()
        {
            var seniorities = new List<Seniority>();

            //Senior
            var seniority = new Seniority()
            {
                Id = 1,
                Level = "Senior"
            };

            seniorities.Add(seniority);

            //Mid
            seniority = new Seniority()
            {
                Id = 2,
                Level = "Mid"
            };

            seniorities.Add(seniority);

            //Junior
            seniority = new Seniority()
            {
                Id = 3,
                Level = "Junior"
            };

            seniorities.Add(seniority);

            return seniorities;
        }
    }
}
