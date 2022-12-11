using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Models.OfferModels;
using JobPortalProject.Infrastructure.Data;
using JobPortalProject.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobPortalProject.Core.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly JobPortalDbContext context;

        public EmployerService(JobPortalDbContext _context)
        {
            context = _context;
        }

        public async Task CreateEmployerAsync(string employeeId, string phoneNumber)
        {
            var employer = new Employer()
            {
                UserId = employeeId,
                PhoneNumber = phoneNumber
            };

            await context.Employers.AddAsync(employer);
            await context.SaveChangesAsync();
        }

        public async Task CreateOfferAsync(string title, string description, decimal salary, int locationId, int seniorityId, int categoryId, int employerId)
        {
            var offer = new Offer()
            {
                Title = title,
                Description = description,
                CreatedOn = DateTime.Now.Date,
                Salary = salary,
                LocationId = locationId,
                SeniorityId = seniorityId,
                CategoryId = categoryId,
                EmployerId = employerId
            };

            await context.Offers.AddAsync(offer);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int offerId)
        {
            var offer = await context.Offers
                .FirstAsync(o => o.Id == offerId);

            context.Remove(offer);
            await context.SaveChangesAsync();
        }

        public async Task EditfferAsync(int offerId, string title, string description, decimal salary, int locationId, int seniorityId, int categoryId)
        {
            var offer = await context.Offers
                .FirstAsync(o => o.Id == offerId);

            offer.Title = title;
            offer.Description = description;
            offer.Salary = salary;
            offer.LocationId = locationId;
            offer.SeniorityId = seniorityId;
            offer.CategoryId = categoryId;

            await context.SaveChangesAsync();
        }

        public bool EmployeeWithPhoneNumberExists(string phoneNumber)
        {
            return context.Employers
                .Any(e => e.PhoneNumber == phoneNumber);
        }

        public async Task<bool> ExistsById(string userId)
        {
            return await context.Employers
                .AnyAsync(e => e.UserId == userId);
        }

        public async Task<int> GetEmployerId(string userId)
        {
            var employer = await context.Employers
                .FirstOrDefaultAsync(e => e.UserId == userId);

            return employer.Id;
        }

        public async Task<IEnumerable<OfferViewModel>> GetMyOffersAsync(int employerId)
        {
            var offers = await context.Offers
                .Where(o => o.EmployerId == employerId)
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
                .ToListAsync();

            return offers;
        }
    }
}
