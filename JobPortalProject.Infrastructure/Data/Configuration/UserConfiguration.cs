using JobPortalProject.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobPortalProject.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(CreateUsers());
        }

        private List<Employee> CreateUsers()
        {
            var users = new List<Employee>();
            var hasher = new PasswordHasher<Employee>();

            //Admin - user/admin
            var user = new Employee()
            {
                Id = "5425a9af-d8cc-4bef-ab04-dde36a0ea47e",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "Admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM"
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "Admin@123");

            users.Add(user);

            //Apple - user/employer
            user = new Employee()
            {
                Id = "fe503507-9126-4d35-a7cc-d4a3c1ee931c",
                UserName = "Apple",
                NormalizedUserName = "APPLE",
                Email = "Apple@gmail.com",
                NormalizedEmail = "APPLE@GMAIL.COM"
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "Apple@123");

            users.Add(user);

            //Microsoft - user/employer
            user = new Employee()
            {
                Id = "93df1c24-aabb-46fd-8809-ccd70959c7f0",
                UserName = "Microsoft",
                NormalizedUserName = "MICROSOFT",
                Email = "Microsoft@gmail.com",
                NormalizedEmail = "MICROSOFT@GMAIL.COM"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "Microsoft@123");

            users.Add(user);

            //John - user/employee
            user = new Employee()
            {
                Id = "ea151599-df73-482a-8332-658ac822f086",
                UserName = "John",
                NormalizedUserName = "JOHN",
                Email = "John@gmail.com",
                NormalizedEmail = "JOHN@GMAIL.COM",
                CV = "I have 3 years of expirence in .NET."
            };

            user.PasswordHash =
            hasher.HashPassword(user, "John@123");

            users.Add(user);

            //Mike - user/employee
            user = new Employee()
            {
                Id = "24503cd9-443e-44c9-9264-564feeaae46a",
                UserName = "Mike",
                NormalizedUserName = "MIKE",
                Email = "Mike@gmail.com",
                NormalizedEmail = "MIKE@GMAIL.COM",
                CV = "I have no years of expirence in JS. Currently looking for an internship."
            };

            user.PasswordHash =
            hasher.HashPassword(user, "Mike@123");

            users.Add(user);

            //Ivan - user/employee
            user = new Employee()
            {
                Id = "fc204c28-2af1-4235-a4b8-a3db0576c94b",
                UserName = "Ivan",
                NormalizedUserName = "IVAN",
                Email = "Ivan@gmail.com",
                NormalizedEmail = "IVAN@GMAIL.COM",
                CV = "I have 6 years of expirence in Python."
            };

            user.PasswordHash =
            hasher.HashPassword(user, "Ivan@123");

            users.Add(user);

            return users;
        }
    }
}
