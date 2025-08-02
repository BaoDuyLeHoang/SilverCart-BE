using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities.Stocks;
using SilverCart.Domain.Entities.Stores;

namespace Infrastructures.FluentAPIs
{
    public class AddressConfiguration : IEntityTypeConfiguration<SavedAddress>, IEntityTypeConfiguration<StoreAddress>
    {
        public void Configure(EntityTypeBuilder<SavedAddress> builder)
        {
            builder.ToTable("Addresses");
            builder.Property(a => a.StreetAddress).IsRequired();
            builder.Property(a => a.WardCode).IsRequired();
            builder.Property(a => a.DistrictId).IsRequired();
            builder.Property(a => a.DistrictName).IsRequired();
            builder.Property(a => a.ProvinceName).IsRequired();
        }

        public void Configure(EntityTypeBuilder<StoreAddress> builder)
        {
            builder.ToTable("StoreAddresses");
            builder.Property(sa => sa.StreetAddress).IsRequired();
            builder.Property(sa => sa.WardCode).IsRequired();
            builder.Property(sa => sa.DistrictId).IsRequired();
            builder.Property(sa => sa.DistrictName).IsRequired().HasMaxLength(255);
            builder.Property(sa => sa.ProvinceName).IsRequired().HasMaxLength(255);
            builder.Property(sa => sa.WardName).IsRequired().HasMaxLength(255);
            builder.HasOne(sa => sa.Store).WithOne(s => s.StoreAddress).HasForeignKey<Store>(s => s.StoreAddressId);
        }
    }
}