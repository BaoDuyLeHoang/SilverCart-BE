using Infrastructures;
using Infrastructures.FluentAPIs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using SilverCart.Infrastructure.Commons;

namespace WebAPI.Extensions
{
    public static class SeedDataExtension
    {
        public static async Task SeedDatabaseAsync(this IApplicationBuilder applicationBuilder,
            AppConfiguration configuration)
        {
            
            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<AppDbContext>();
            await dbContext.Database.MigrateAsync();
            
            var _userManager = services.GetRequiredService<UserManager<BaseUser>>();
            if (await _userManager.FindByEmailAsync(configuration.SuperAdmin.Email) == null)
            {
                var superAdmin = new AdministratorUser()
                {
                    UserName = configuration.SuperAdmin.Email,
                    Email = configuration.SuperAdmin.Email,
                    FullName = "Siêu Admin",
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(superAdmin, configuration.SuperAdmin.Password);
                if (!result.Succeeded)
                {
                    throw new Exception("Failed to create super admin user: " +
                                        string.Join(", ", result.Errors.Select(e => e.Description)));
                }

                await _userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
            }


        }
    }
}