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
            builder.ToTable("Products");
        }

        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.ToTable("ProductVariants");
        }

        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.ToTable("ProductItems");
        }

        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");
        }

        public void Configure(EntityTypeBuilder<ProductPromotion> builder)
        {
            builder.ToTable("ProductPromotions");
            builder.HasOne(x => x.Product).WithMany(x => x.ProductPromotions).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Promotion).WithMany(x => x.ProductPromotions).HasForeignKey(x => x.PromotionId);
        }
    }
}