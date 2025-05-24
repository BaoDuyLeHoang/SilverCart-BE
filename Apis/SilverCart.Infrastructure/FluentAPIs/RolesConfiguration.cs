using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures.FluentAPIs;

public class RolesConfiguration : IEntityTypeConfiguration<StoreRole>, IEntityTypeConfiguration<AdministratorRole>,
    IEntityTypeConfiguration<CustomerRole>, IEntityTypeConfiguration<StoreUserRole>
{
    public void Configure(EntityTypeBuilder<StoreRole> builder)
    {
        builder.ToTable("StoreRoles");
        List<string> roles = ["StoreOwner", "StoreManager", "StoreDelivery", "StoreSupport"];


        builder.HasData(
            roles.Select(role => new StoreRole
            {
                Id = Guid.NewGuid(),
                Name = role,
                NormalizedName = role.ToUpper(),
                Description = ""
            })
        );
    }

    public void Configure(EntityTypeBuilder<AdministratorRole> builder)
    {
        builder.ToTable("AdministratorRoles");
        List<string> roles = ["SuperAdmin", "Admin", "Staff", "Moderator", "CustomerSupport"];
        builder.HasData(
            roles.Select(role => new AdministratorRole
            {
                Id = Guid.NewGuid(),
                Name = role,
                NormalizedName = role.ToUpper(),
                Description = ""
            })
        );
    }

    public void Configure(EntityTypeBuilder<CustomerRole> builder)
    {
        builder.ToTable("CustomerRoles");
        // builder.HasMany(x => x.Customers).WithMany().UsingEntity("CustomerUserRoles");
        List<string> roles = ["Guardian", "Customer", "DependentUser"];
        builder.HasData(
            roles.Select(role => new CustomerRole
            {
                Id = Guid.NewGuid(),
                Name = role,
                NormalizedName = role.ToUpper(),
                Description = ""
            })
        );
    }

    public void Configure(EntityTypeBuilder<StoreUserRole> builder)
    {
        builder.ToTable("StoreUserRoles");

        builder.HasKey(x => new { x.UserId, x.RoleId });
    }
}