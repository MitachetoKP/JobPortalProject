using JobPortalProject.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace JobPortalProject.Core.Infrastructure
{
    public static class ApplicationBuilderExtensions 
    {
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var services = scopedServices.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<Employee>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync("Admin"))
                    {
                        return;
                    }

                    var role = new IdentityRole
                    {
                        Name = "Admin"
                    };

                    await roleManager.CreateAsync(role);

                    var admin = await userManager.FindByNameAsync("Admin");

                    await userManager.AddToRoleAsync(admin, role.Name);
                })
                .GetAwaiter()
                .GetResult();

            return app;
        }
    }
}
