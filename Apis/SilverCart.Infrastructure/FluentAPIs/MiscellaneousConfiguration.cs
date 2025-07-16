using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities.Stocks;

namespace Infrastructures.FluentAPIs
{
    public class MiscellaneousConfiguration : IEntityTypeConfiguration<Address>,
        IEntityTypeConfiguration<StockHistory>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.Property(a => a.StreetAddress).IsRequired();
            builder.Property(a => a.WardCode).IsRequired();
            builder.Property(a => a.DistrictId).IsRequired();
            builder.Property(a => a.ToDistrictName).IsRequired();
            builder.Property(a => a.ToProvinceName).IsRequired();
            builder.HasOne(a => a.Customer).WithMany(c => c.Addresses).HasForeignKey(a => a.CustomerId);
        }

        public void Configure(EntityTypeBuilder<StockHistory> builder)
        {
            builder.ToTable("StockHistories");
            builder.HasOne(sh => sh.ProductItem)
           .WithMany()
           .HasForeignKey(sh => sh.ProductItemId);

        }

    }
}