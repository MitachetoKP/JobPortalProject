using JobPortalProject.Core.Contracts;
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
    }
}
