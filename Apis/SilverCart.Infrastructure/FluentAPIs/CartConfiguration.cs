using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities.Carts;

namespace SilverCart.Infrastructure.FluentAPIs;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts");

        // Properties
        builder.Property(c => c.UserId)
            .IsRequired();

        builder.Property(c => c.TotalPrice)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(c => c.IsConsultantUserRecommend)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(c => c.ConsultantRecommendation)
            .IsRequired()
            .HasDefaultValue(false);

        // Foreign keys
        builder.Property(c => c.CustomerUserId)
            .IsRequired(false);

        builder.Property(c => c.GuardianUserId)
            .IsRequired(false);

        builder.HasMany(c => c.CartItems)
            .WithOne(ci => ci.Cart)
            .HasForeignKey(ci => ci.CartId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(c => c.UserId)
            .IsUnique();
    }
}