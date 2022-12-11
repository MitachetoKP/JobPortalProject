using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Models.SeniorityModels;
using JobPortalProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobPortalProject.Core.Services
{
    public class SeniorityService : ISeniorityService
    {
        private JobPortalDbContext context;

        public SeniorityService(JobPortalDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<SeniorityViewModel>> GetAllAsync()
        {
            var seniorities = await context.Seniorities
               .Select(s => new SeniorityViewModel()
               {
                   Id = s.Id,
                   Level = s.Level
               })
               .ToListAsync();

            return seniorities;
        }

        public async Task<int> GetSeniorityIdAsync(int offerId)
        {
            var offer = await context.Offers
                .FirstAsync(o => o.Id == offerId);

            return offer.SeniorityId;
        }

        public async Task<bool> SeniorityExists(int seniorityId)
        {
            return await context.Seniorities
                .AnyAsync(s => s.Id == seniorityId);
        }
    }
}
