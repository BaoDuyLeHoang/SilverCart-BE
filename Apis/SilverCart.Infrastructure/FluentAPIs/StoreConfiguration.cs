using SilverCart.Domain.Entities.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Products;

namespace Infrastructures.FluentAPIs
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>,
        IEntityTypeConfiguration<StoreRole>,
        IEntityTypeConfiguration<StoreUserRole>,
        IEntityTypeConfiguration<StoreAddress>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Stores");

            // Configure relationships
            builder.HasMany<Product>(s => s.Products)
                .WithOne(p => p.Store)
                .HasForeignKey(p => p.StoreId)
                .OnDelete(DeleteBehavior.Restrict);

            #region Stores Data
            // Seed data for Store - ONLY ONE STORE
            builder.HasData(
                new Store
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                    Name = "Nhà thuốc Độc Lập",
                    Description = "Cửa hàng độc lập chuyên cung cấp thiết bị y tế và thuốc cho người cao tuổi",
                    AvatarPath = "/images/stores/doc-lap.jpg",
                    Phone = "028-1234-5678",
                    StoreAddressId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    CreationDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsDeleted = false
                }
            );
            #endregion
        }

        public void Configure(EntityTypeBuilder<StoreRole> builder)
        {
            builder.ToTable("StoreRoles");
        }

        public void Configure(EntityTypeBuilder<StoreUserRole> builder)
        {
            builder.ToTable("StoreUserRoles");
        }

        public void Configure(EntityTypeBuilder<StoreAddress> builder)
        {
            builder.ToTable("StoreAddresses");
            builder.Property(sa => sa.Address).HasMaxLength(255);
            builder.Property(sa => sa.WardCode).HasMaxLength(255);
            builder.Property(sa => sa.DistrictId).HasMaxLength(255);
            builder.Property(sa => sa.WardName).HasMaxLength(255);
            builder.Property(sa => sa.DistrictName).HasMaxLength(255);
            builder.Property(sa => sa.ProvinceName).HasMaxLength(255);

            #region StoreAddress Data
            builder.HasData(
                new StoreAddress
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    Address = "123 Đường Độc Lập",
                    WardCode = "00001",
                    DistrictId = 1,
                    WardName = "Phường 1",
                    DistrictName = "Quận 1",
                    ProvinceName = "TP.HCM",
                    CreationDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsDeleted = false
                }
            );
            #endregion
        }
    }
}