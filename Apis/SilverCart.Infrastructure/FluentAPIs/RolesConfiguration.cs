using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures.FluentAPIs;

public class RolesConfiguration : IEntityTypeConfiguration<StoreRole>, IEntityTypeConfiguration<AdministratorRole>,
    IEntityTypeConfiguration<CustomerRole>, IEntityTypeConfiguration<StoreUserRole>, IEntityTypeConfiguration<ConsultantRole>
{
    public void Configure(EntityTypeBuilder<StoreRole> builder)
    {
        builder.ToTable("StoreRoles");

        builder.HasData(
            new StoreRole
            {
                Id = Guid.Parse("60cb3e42-0903-4c3f-8e9c-bfdc6f6a1a01"),
                Name = "StoreOwner",
                NormalizedName = "STOREOWNER",
                Description = ""
            },
            new StoreRole
            {
                Id = Guid.Parse("a2a02247-2a41-4a38-8804-4be8038fa78b"),
                Name = "StoreSupport",
                NormalizedName = "STORESUPPORT",
                Description = ""
            }
        );
    }

    public void Configure(EntityTypeBuilder<AdministratorRole> builder)
    {
        builder.ToTable("AdministratorRoles");
<<<<<<< HEAD

=======
        List<string> roles = ["SuperAdmin", "Admin", "Staff", "Moderator", "CustomerSupport", "Consultant"];
>>>>>>> 8f1555a34ed75f6ac7854bab98b248deb8824077
        builder.HasData(
            new AdministratorRole
            {
                Id = Guid.Parse("5c2cb3f3-d9b1-4d5f-8a9c-1e6f689ee0f4"),
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Description = ""
            },
            new AdministratorRole
            {
                Id = Guid.Parse("0e61cc83-d3c4-43b1-9334-8dd0c9d22833"),
                Name = "Admin",
                NormalizedName = "ADMIN",
                Description = ""
            }
        );
    }

    public void Configure(EntityTypeBuilder<CustomerRole> builder)
    {
        builder.ToTable("CustomerRoles");

        builder.HasData(
            new CustomerRole
            {
                Id = Guid.Parse("0c09b112-baf9-4ec3-bc79-cce452219d60"),
                Name = "Guardian",
                NormalizedName = "GUARDIAN",
                Description = ""
            },
            new CustomerRole
            {
                Id = Guid.Parse("2c8499d3-6ec2-4745-b2f7-6e33182f6f6f"),
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                Description = ""
            },
            new CustomerRole
            {
                Id = Guid.Parse("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1b"),
                Name = "DependentUser",
                NormalizedName = "DEPENDENTUSER",
                Description = ""
            }
        );
    }

    public void Configure(EntityTypeBuilder<StoreUserRole> builder)
    {
        builder.ToTable("StoreUserRoles");

        builder.HasKey(x => new { x.UserId, x.RoleId });
    }

    public void Configure(EntityTypeBuilder<ConsultantRole> builder)
    {
        builder.ToTable("ConsultantRoles");

    }
}
