using JobPortalProject.Infrastructure.Data.Configuration;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new LocationConfiguration());
            builder.ApplyConfiguration(new SeniorityConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new OfferConfiguration());
            builder.ApplyConfiguration(new EmployerConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Employer> Employers { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Seniority> Seniorities { get; set; }

    }
}