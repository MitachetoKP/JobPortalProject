using JobPortalProject.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalProject.Infrastructure.Data.Configuration
{
    public class EmployerConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.HasData(CreateEmployers());
        }

        private List<Employer> CreateEmployers()
        {
            var employers = new List<Employer>();

            //Admin - employer
            var employer = new Employer()
            {
                Id = 1,
                PhoneNumber = "0123456789",
                UserId = "5425a9af-d8cc-4bef-ab04-dde36a0ea47e"
            };

            employers.Add(employer);

            //Apple - employer
            employer = new Employer()
            {
                Id = 2,
                PhoneNumber = "0347648933",
                UserId = "fe503507-9126-4d35-a7cc-d4a3c1ee931c"
            };

            employers.Add(employer);

            //Microsoft - employer
            employer = new Employer()
            {
                Id = 3,
                PhoneNumber = "04738945673",
                UserId = "93df1c24-aabb-46fd-8809-ccd70959c7f0"
            };

            employers.Add(employer);

            return employers;
        }
    }
}
