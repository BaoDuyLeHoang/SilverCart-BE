using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Products;
using SilverCart.Domain.Entities.Stores;

namespace Infrastructures.FluentAPIs
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>,
        IEntityTypeConfiguration<ProductVariant>,
        IEntityTypeConfiguration<ProductItem>,
        IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            // Configure relationships
            builder.HasMany(p => p.Variants)
                .WithOne(pv => pv.Product)
                .HasForeignKey(pv => pv.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasMany(p => p.ProductPromotions)
                .WithOne(pp => pp.Product)
                .HasForeignKey(pp => pp.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasOne(p => p.Store)
                .WithMany()
                .HasForeignKey(p => p.StoreId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // Configure properties
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(10000);
        }

        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.ToTable("ProductVariants");

            // Configure relationships
            builder.HasOne(pv => pv.Product)
                .WithMany(p => p.Variants)
                .HasForeignKey(pv => pv.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasMany(pv => pv.ProductItems)
                .WithOne(pi => pi.Variant)
                .HasForeignKey(pi => pi.VariantId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            // Configure properties
            builder.Property(pv => pv.VariantName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(pv => pv.IsActive)
                .IsRequired()
                .HasDefaultValue(true);
        }

        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.ToTable("ProductItems");

            // Configure relationships
            builder.HasOne(pi => pi.Variant)
                .WithMany(pv => pv.ProductItems)
                .HasForeignKey(pi => pi.VariantId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasOne(pi => pi.Stock)
                .WithOne()
                .HasForeignKey<ProductItem>(pi => pi.StockId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasMany(pi => pi.ProductImages)
                .WithOne(pi => pi.ProductItem)
                .HasForeignKey(pi => pi.ProductItemId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            // Configure properties
            builder.Property(pi => pi.SKU)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(pi => pi.OriginalPrice)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(pi => pi.DiscountedPrice)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(pi => pi.IsActive)
                .IsRequired()
                .HasDefaultValue(true);
        }

        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");

            // Configure relationships
            builder.HasOne(pi => pi.ProductItem)
                .WithMany(pi => pi.ProductImages)
                .HasForeignKey(pi => pi.ProductItemId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            // Configure properties
            builder.Property(pi => pi.ImagePath)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(pi => pi.ImageName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(pi => pi.IsMain)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(pi => pi.Order)
                .IsRequired()
                .HasDefaultValue(0);
        }
    }
}