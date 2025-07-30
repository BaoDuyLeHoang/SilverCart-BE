using SilverCart.Domain.Entities.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Products;
using Microsoft.Extensions.Configuration;

namespace Infrastructures.FluentAPIs
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>,
        IEntityTypeConfiguration<StoreRole>,
        IEntityTypeConfiguration<StoreUserRole>,
        IEntityTypeConfiguration<StoreAddress>
    {
        private static IConfiguration _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ? "appsettings.Development.json" : "appsettings.json", optional: false, reloadOnChange: true)
                .Build();

        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Stores");

            // Configure relationships
            builder.HasMany(s => s.Products)
                .WithOne(p => p.Store)
                .HasForeignKey(p => p.StoreId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.StoreAddress).WithOne(sa => sa.Store).HasForeignKey<Store>(s => s.StoreAddressId);
            builder.HasMany(s => s.StoreUsers).WithOne(su => su.Store).HasForeignKey(su => su.StoreId);

            #region Stores Data
            // Seed data for Store - ONLY ONE STORE
            builder.HasData(
                new Store
                {
                    Id = Guid.Parse(_configuration["StoreSettings:Id"]),
                    Name = "Nhà thuốc Độc Lập",
                    GhnShopId = int.Parse(_configuration["Ghn:ShopId"]),
                    Description = "Cửa hàng độc lập chuyên cung cấp thiết bị y tế và thuốc cho người cao tuổi",
                    AvatarPath = "/images/stores/store.jpg",
                    Phone = "02812345678",
                    StoreAddressId = Guid.Parse(_configuration["StoreSettings:AddressId"]),
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

            #region StoreAddress Data
            builder.HasData(
                new StoreAddress
                {
                    Id = Guid.Parse(_configuration["StoreSettings:AddressId"]),
                    StreetAddress = "123 Lê Văn Việt",
                    WardName = "Phường Hiệp Phú",
                    DistrictName = "Quận 9",
                    DistrictId = 1451,
                    WardCode = "20901",
                    ProvinceId = 202,
                    ProvinceName = "Hồ Chí Minh",
                    StoreId = Guid.Parse(_configuration["StoreSettings:Id"]),
                    CreationDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsDeleted = false
                }
            );
            #endregion
        }
    }
}