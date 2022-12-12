using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Models.UserModels;
using JobPortalProject.Infrastructure.Data;
using JobPortalProject.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JobPortalProject.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private JobPortalDbContext context;

        public EmployeeService(JobPortalDbContext _context)
        {
            context = _context;
        }

        public async Task EditInfoAsync(string employeeId, string newUserName, string newEmail, string newCV)
        {
            var employee = await context.Employees
                .FirstOrDefaultAsync(e => e.Id == employeeId);

            employee.UserName = newUserName;
            employee.NormalizedUserName = newUserName.ToUpper();
            employee.Email = newEmail;
            employee.NormalizedEmail = newEmail.ToUpper();
            employee.CV = newCV;

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var users = await context.Employees
                .Select(e => new UserModel()
                {
                    UserName = e.UserName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber
                })
                .ToListAsync();

            return users;
        }

        public async Task<UserViewModel> GetUser(string employeeId)
        {
            var employee = await context.Employees
                .FirstOrDefaultAsync(e => e.Id == employeeId);

            var model = new UserViewModel()
            {
                Id = employee.Id,
                UserName = employee.UserName,
                Email = employee.Email,
                Password = employee.PasswordHash,
                CV = employee.CV
            };

            return model;
        }
    }
}
