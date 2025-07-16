using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities.Stocks;

namespace Infrastructures.FluentAPIs;

public class StockConfiguration : IEntityTypeConfiguration<Stock>, IEntityTypeConfiguration<StockHistory>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable("Stocks");
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.ReservedQuantity).IsRequired();
        builder.Property(x => x.AvailableQuantity).IsRequired();

        // Configure one-to-one relationship with ProductItem
        builder.HasOne(s => s.ProductItem)
            .WithOne(pi => pi.Stock)
            .HasForeignKey<Stock>(s => s.ProductItemId);

        #region Seed Data - Match ProductItem IDs from ProductConfiguration
        builder.HasData(
            // Stock for ProductItem ID: 11111111-1111-1111-1111-111111111141 (OMRON-HEM-7130-WHITE-DL)
            new Stock
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111161"),
                ProductItemId = Guid.Parse("11111111-1111-1111-1111-111111111141"),
                Quantity = 25,
                ReservedQuantity = 0,
                AvailableQuantity = 25,
                CreationDate = new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7776),
                IsDeleted = false
            },
            // Stock for ProductItem ID: 11111111-1111-1111-1111-111111111142 (ACCU-CHEK-GUIDE-BASIC-DL)
            new Stock
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111162"),
                ProductItemId = Guid.Parse("11111111-1111-1111-1111-111111111142"),
                Quantity = 15,
                ReservedQuantity = 0,
                AvailableQuantity = 15,
                CreationDate = new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7778),
                IsDeleted = false
            },
            // Stock for ProductItem ID: 22222222-2222-2222-2222-222222222230 (ENSURE-GOLD-400G-DL)
            new Stock
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222242"),
                ProductItemId = Guid.Parse("22222222-2222-2222-2222-222222222230"),
                Quantity = 50,
                ReservedQuantity = 0,
                AvailableQuantity = 50,
                CreationDate = new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7780),
                IsDeleted = false
            },
            // Stock for ProductItem ID: 22222222-2222-2222-2222-222222222231 (VITAMIN-D3-K2-60-DL)
            new Stock
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222243"),
                ProductItemId = Guid.Parse("22222222-2222-2222-2222-222222222231"),
                Quantity = 75,
                ReservedQuantity = 0,
                AvailableQuantity = 75,
                CreationDate = new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7782),
                IsDeleted = false
            },
            // Stock for ProductItem ID: 33333333-3333-3333-3333-333333333341 (GAY-CHONG-4-CHAN-BLACK-DL)
            new Stock
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333353"),
                ProductItemId = Guid.Parse("33333333-3333-3333-3333-333333333341"),
                Quantity = 20,
                ReservedQuantity = 0,
                AvailableQuantity = 20,
                CreationDate = new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7784),
                IsDeleted = false
            },
            // Stock for ProductItem ID: 33333333-3333-3333-3333-333333333342 (XE-LAN-TAY-XANH-DL)
            new Stock
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333354"),
                ProductItemId = Guid.Parse("33333333-3333-3333-3333-333333333342"),
                Quantity = 8,
                ReservedQuantity = 0,
                AvailableQuantity = 8,
                CreationDate = new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7786),
                IsDeleted = false
            }
        );
        #endregion
    }

    public void Configure(EntityTypeBuilder<StockHistory> builder)
    {
        builder.ToTable("StockHistories");
        builder.HasOne(x => x.ProductItem)
            .WithMany(x => x.StockHistories)
            .HasForeignKey(x => x.ProductItemId);
    }
}