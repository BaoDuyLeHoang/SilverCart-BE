using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Entities.Stores;
using SilverCart.Domain.Enums;

namespace Infrastructures.FluentAPIs;

public class RolesConfiguration : IEntityTypeConfiguration<StoreRole>, IEntityTypeConfiguration<AdministratorRole>,
    IEntityTypeConfiguration<CustomerRole>, IEntityTypeConfiguration<StoreUserRole>,
    IEntityTypeConfiguration<ConsultantRole>
{
    public void Configure(EntityTypeBuilder<StoreRole> builder)
    {
        builder.ToTable("StoreRoles");

        builder.HasData(
            new StoreRole
            {
                Id = Guid.Parse("60cb3e42-0903-4c3f-8e9c-bfdc6f6a1a01"),
                Name = RoleEnum.ShopOwner.ToString(),
                NormalizedName = RoleEnum.ShopOwner.ToString().ToUpper(),
                Description = "Chủ cửa hàng là người quản lý cửa hàng và có quyền quản lý cửa hàng."
            },
            new StoreRole
            {
                Id = Guid.Parse("a2a02247-2a41-4a38-8804-4be8038fa78b"),
                Name = RoleEnum.Staff.ToString(),
                NormalizedName = RoleEnum.Staff.ToString().ToUpper(),
                Description = "Hỗ trợ cửa hàng là người hỗ trợ cửa hàng và có quyền hỗ trợ cửa hàng."
            }
        );
    }

    public void Configure(EntityTypeBuilder<AdministratorRole> builder)
    {
        builder.ToTable("AdministratorRoles");

        builder.HasData(
            new AdministratorRole
            {
                Id = Guid.Parse("5c2cb3f3-d9b1-4d5f-8a9c-1e6f689ee0f4"),
                Name = RoleEnum.SuperAdmin.ToString(),
                NormalizedName = RoleEnum.SuperAdmin.ToString().ToUpper(),
                Description =
                    "Siêu quản trị viên là người quản lý toàn bộ hệ thống và có quyền quản lý toàn bộ hệ thống."
            },
            new AdministratorRole
            {
                Id = Guid.Parse("0e61cc83-d3c4-43b1-9334-8dd0c9d22833"),
                Name = RoleEnum.Admin.ToString(),
                NormalizedName = "ADMIN",
                Description = "Quản trị viên là người quản lý cửa hàng và có quyền quản lý cửa hàng."
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
                Name = RoleEnum.Guardian.ToString(),
                NormalizedName = "GUARDIAN",
                Description =
                    "Người giám hộ là người giám hộ cho người phụ thuộc và có quyền giám hộ cho người phụ thuộc."
            },
            new CustomerRole
            {
                Id = Guid.Parse("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1b"),
                Name = RoleEnum.DependentUser.ToString(),
                NormalizedName = "DEPENDENTUSER",
                Description =
                    "Người phụ thuộc là người phụ thuộc cho người giám hộ và có quyền phụ thuộc cho người giám hộ."
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

        builder.HasData(
            new ConsultantRole
            {
                Id = Guid.Parse("c66a403b-e1f9-47f3-9f6b-d8c3913b7a19"),
                Name = RoleEnum.Consultant.ToString(),
                NormalizedName = "CONSULTANT",
                Description = "Người tư vấn là người tư vấn cho người khách và có quyền tư vấn cho người khách."
            }
        );
    }
}