using Infrastructures;
using Infrastructures.FluentAPIs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;

namespace WebAPI.Extensions
{
    public static class SeedDataExtension
    {
        public static async Task SeedDatabaseAsync(this IApplicationBuilder applicationBuilder)
        {
            
            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;

            var dbContext = services.GetRequiredService<AppDbContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
