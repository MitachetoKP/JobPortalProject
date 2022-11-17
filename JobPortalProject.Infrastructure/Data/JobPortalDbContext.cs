using JobPortalProject.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobPortalProject.Infrastructure.Data
{
    public class JobPortalDbContext : IdentityDbContext<Employee>
    {
        public JobPortalDbContext(DbContextOptions<JobPortalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Employer> Employers { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Seniority> Seniorities { get; set; }

    }
}