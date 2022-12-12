using JobPortalProject.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortalProject.Infrastructure.Data.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(CreateLocations());
        }

        private List<Location> CreateLocations()
        {
            var locations = new List<Location>();

            //Sofia
            var location = new Location()
            {
                Id = 1,
                Name = "Sofia",
            };

            locations.Add(location);

            //Plovdiv
            location = new Location()
            {
                Id = 2,
                Name = "Plovdiv",
            };

            locations.Add(location);

            //Remote
            location = new Location()
            {
                Id = 3,
                Name = "Remote",
            };

            locations.Add(location);

            return locations;
        }
    }
}
