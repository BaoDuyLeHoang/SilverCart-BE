using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Promotions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>,
        IEntityTypeConfiguration<UserPromotion>,
        IEntityTypeConfiguration<ProductPromotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.ToTable("Promotions");

            builder.HasMany(p => p.ProductPromotions)
                .WithOne(pp => pp.Promotion)
                .HasForeignKey(pp => pp.PromotionId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            // Add global query filter
        }

        public void Configure(EntityTypeBuilder<UserPromotion> builder)
        {
            builder.ToTable("UserPromotions");

            builder.HasOne(up => up.User)
                .WithMany()
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(up => up.Promotion)
                .WithMany()
                .HasForeignKey(up => up.PromotionId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void Configure(EntityTypeBuilder<ProductPromotion> builder)
        {
            builder.ToTable("ProductPromotions");
            builder.HasKey(pp => new { pp.ProductId, pp.PromotionId });

            builder.HasOne(pp => pp.Product)
                .WithMany(p => p.ProductPromotions)
                .HasForeignKey(pp => pp.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasOne(pp => pp.Promotion)
                .WithMany(p => p.ProductPromotions)
                .HasForeignKey(pp => pp.PromotionId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            // Add matching query filter
            builder.HasQueryFilter(x => !x.Product.IsDeleted && !x.Promotion.IsDeleted);
        }
    }
}