using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Models.CategoryModels;
using JobPortalProject.Core.Models.LocationModels;
using JobPortalProject.Core.Models.OfferModels;
using JobPortalProject.Core.Models.UserModels;
using JobPortalProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
                    CreatedOn = o.CreatedOn.ToShortDateString(),
                    Category = o.Category.Title,
                    Salary = $"{o.Salary:f0}",
                    Employer = o.Employer.User.UserName,
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
                .Select(l => new LocationViewModel()
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
                    Employer = o.Employer.User.UserName,
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

        public async Task<bool> Exists(int offerId)
        {
            return await context.Offers
                .AnyAsync(o => o.Id == offerId);
        }

        public async Task<bool> HasEmployerWithIdAsync(int offerId, string employeeId)
        {
            var offer = await context.Offers
                .FirstOrDefaultAsync(o => o.Id == offerId);

            if (offer == null)
            {
                return false;
            }

            var employer = await context.Employers
                .FirstOrDefaultAsync(e => e.Id == offer.EmployerId);

            if (employer == null)
            {
                return false;
            }

            if (employer.UserId != employeeId)
            {
                return false;
            }

            return true;
        }

        public async Task<EmployeeListModel> GetAppliedAsync(int offerId)
        {
            var offer = await context.Offers
                .Include(o => o.AppliedEmployees)
                .FirstAsync(o => o.Id == offerId);

            var employees = offer.AppliedEmployees
                .Select(e => new EmployeeViewModel()
                {
                    UserName = e.UserName,
                    Email = e.Email,
                    CV = e.CV
                })
                .ToList();

            var listModel = new EmployeeListModel()
            {
                OfferTitle = offer.Title,
                Employees = employees
            };

            return listModel;
        }
    }
}
