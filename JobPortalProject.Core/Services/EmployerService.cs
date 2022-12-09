using JobPortalProject.Core.Contracts;
using JobPortalProject.Infrastructure.Data;
using JobPortalProject.Infrastructure.Data.Entities;
using JobPortalProject.Core.Infrastructure;


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

        public bool EmployeeWithPhoneNumberExists(string phoneNumber)
        {
            return context.Employers
                .Any(e => e.PhoneNumber == phoneNumber);
        }

        public bool ExistsById(string userId)
        {
            return context.Employers
                .Any(e => e.UserId == userId);
        }
    }
}
