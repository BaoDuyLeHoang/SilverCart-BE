using Application.Commons;
using Application.Utils;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;

namespace Infrastructures.FluentAPIs;

public static class SeedDataExtension
{
    public static void SeedData(this ModelBuilder modelBuilder, AppConfiguration configuration)
    {
        modelBuilder.Entity<AdministratorRole>().HasData(
            new AdministratorRole()
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Description = "Super Admin Role with all permissions",
            },
            new AdministratorRole()
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Description = "Admin Role ",
            }
        );
        modelBuilder.Entity<StoreRole>().HasData(
            new StoreRole()
            {
                Name = "Manager",
                NormalizedName = "Store Manager",
                Description = "",
            },
            new StoreRole()
            {
                Name = "Service",
                NormalizedName = "Service",
                Description = "",
            }
        );
        modelBuilder.Entity<AdministratorUser>().HasData(
            new AdministratorUser
            {
                Email = configuration.SuperAdmin.Email,
                PasswordHash = configuration.SuperAdmin.Password.Hash(),
                FirstName = "Super",
                LastName = "Admin",
                Phone = "",
                IsVerified = true,
            }
        );
    }
}