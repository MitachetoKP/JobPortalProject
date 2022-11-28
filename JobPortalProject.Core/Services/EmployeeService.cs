using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Models.UserModels;
using JobPortalProject.Infrastructure.Data;
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

        public async Task<EmployeeViewModel> GetPersonalInfo(string employeeId)
        {
            var employee = await context.Employees
                .FirstOrDefaultAsync(e => e.Id == employeeId);

            var model = new EmployeeViewModel()
            {
                UserName = employee.UserName,
                Email = employee.Email,
                Password = employee.PasswordHash,
                CV = employee.CV
            };

            return model;
        }
    }
}
