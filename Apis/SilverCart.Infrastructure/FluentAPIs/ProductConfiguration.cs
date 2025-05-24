using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>,
        IEntityTypeConfiguration<ProductVariant>,
        IEntityTypeConfiguration<ProductItem>,
        IEntityTypeConfiguration<ProductImage>,
        IEntityTypeConfiguration<ProductPromotion>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Configure Name
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Configure Description
            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            // Configure VideoPath
            builder.Property(x => x.VideoPath)
                .HasMaxLength(500);

            // Configure ProductType
            builder.Property(x => x.ProductType)
                .IsRequired();

            // Relationships


            // Variants (One-to-Many)
            builder.HasMany(x => x.Variants)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Promotions (One-to-Many with ProductPromotion)
            builder.HasMany(x => x.ProductPromotions)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // IsDeleted property is handled globally by BaseEntitiesConfiguration
        }

        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            // Basic properties
            builder.Property(x => x.VariantName)
                .IsRequired()
                .HasMaxLength(200);

            // Items (One-to-Many)
            builder.HasMany(x => x.Items)
                .WithOne(x => x.Variant)
                .HasForeignKey(x => x.VariantId)
                .OnDelete(DeleteBehavior.Cascade);

            // Product relationship is already defined in Product entity
        }

        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            // Configure properties
            builder.Property(x => x.SKU)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.OriginalPrice)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.DiscountedPrice)
                .HasPrecision(18, 2)
                .IsRequired();

        }

        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            // Configure properties
            builder.Property(x => x.ImagePath)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.ImageName)
                .HasMaxLength(200);

            // Relationship with Product is already defined in Product entity

            // Ensure proper nullable foreign key behavior
            builder.Property(x => x.ProductItemId).IsRequired(false);
        }

        public void Configure(EntityTypeBuilder<ProductPromotion> builder)
        {
            // Configure composite key
            // builder.HasKey(x => new { x.ProductId, x.PromotionId, x.Id });

            // Configure relationship with Promotion
            builder.HasOne(x => x.Promotion)
                .WithMany()
                .HasForeignKey(x => x.PromotionId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            // Product relationship is already defined in Product entity
        }
    }
}