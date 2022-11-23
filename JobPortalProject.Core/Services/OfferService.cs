using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Models.OfferModels;
using JobPortalProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalProject.Core.Services
{
    public class OfferService : IOfferService
    {
        private JobPortalDbContext context;

        public OfferService(JobPortalDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<AllOfferViewModel>> GetAllAsync(int categoryId)
        {
            var offers = await context.Offers
                .Where(o => o.CategoryId == categoryId)
                .Select(o => new AllOfferViewModel()
                {
                    Title = o.Title,
                    CreatedOn = o.CreatedOn.ToLongDateString(),
                    Salary = $"{o.Salary:f2}",
                    Employer = o.Employer.Name,
                    Location = o.Location.Name,
                    Seniority = o.Seniority.Level
                })
                .ToListAsync();

            return offers;
        }
    }
}
