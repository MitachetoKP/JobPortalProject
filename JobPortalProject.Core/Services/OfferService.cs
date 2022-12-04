using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Models.CategoryModels;
using JobPortalProject.Core.Models.LocationModels;
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

        public async Task ApplyForOfferAsync(int offerId, string employeeId)
        {
            var offer = await context.Offers
                .FirstOrDefaultAsync(o => o.Id == offerId);

            var employee = await context.Employees
                .FirstOrDefaultAsync(e => e.Id == employeeId);

            offer.AppliedEmployees.Add(employee);

            await context.SaveChangesAsync();
        }

        public async Task<OfferListModel> GetAllAsync(int categoryId, int locationId)
        {
            var offers = await context.Offers
                .Where(o => o.CategoryId == categoryId && o.LocationId == locationId)
                .Select(o => new OfferViewModel()
                {
                    Id = o.Id,
                    Title = o.Title,
                    Description = o.Description,
                    CreatedOn = o.CreatedOn.ToShortDateString(),
                    Category = o.Category.Title,
                    Salary = $"{o.Salary:f0}",
                    Employer = o.Employer.Name,
                    Location = o.Location.Name,
                    Seniority = o.Seniority.Level
                })
                .ToListAsync();

            var category = await context.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Title = c.Title
                })
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            var locations = await context.Locations
                .Select(l => new locationViewModel()
                {
                    Id = l.Id,
                    Name = l.Name,
                    OffersCount = l.Offers
                    .Where(o => o.CategoryId == categoryId)
                    .Count()
                })
                .ToListAsync();

            OfferListModel model = new OfferListModel()
            {
                Offers = offers,
                Category = category,
                Locations = locations,
            };

            return model;
        }

        public async Task<OfferViewModel> GetOfferAsync(int offerId)
        {
            var offer = await context.Offers
                .Select(o => new OfferViewModel()
                {
                    Id = o.Id,
                    Title = o.Title,
                    Description = o.Description,
                    CreatedOn = o.CreatedOn.ToShortDateString(),
                    Category = o.Category.Title,
                    Salary = $"{o.Salary:f0}",
                    Employer = o.Employer.Name,
                    Location = o.Location.Name,
                    Seniority = o.Seniority.Level
                })
                .FirstOrDefaultAsync(o => o.Id == offerId);

            return offer;
        }

        public async Task<bool> IsApplied(int offerId, string employeeId)
        {
            var offer = await context.Offers
                .Include(o => o.AppliedEmployees)
                .FirstOrDefaultAsync(o => o.Id == offerId);

            var employee = await context.Employees
                .FirstOrDefaultAsync(e => e.Id == employeeId);

            if (offer.AppliedEmployees.Contains(employee))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
