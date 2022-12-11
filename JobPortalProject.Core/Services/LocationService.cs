using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Models.LocationModels;
using JobPortalProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobPortalProject.Core.Services
{
    public class LocationService : ILocationService
    {
        private JobPortalDbContext context;

        public LocationService(JobPortalDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<LocationViewModel>> GetAllAsync()
        {
            var locations = await context.Locations
                .Select(l => new LocationViewModel()
                {
                    Id = l.Id,
                    Name = l.Name
                })
                .ToListAsync();

            return locations;
        }

        public async Task<int> GetLocationIdAsync(int offerId)
        {
            var offer = await context.Offers
                .FirstAsync(o => o.Id == offerId);

            return offer.LocationId;
        }

        public async Task<bool> LocationExists(int locationId)
        {
            return await context.Locations
                .AnyAsync(l => l.Id == locationId);
        }
    }
}
