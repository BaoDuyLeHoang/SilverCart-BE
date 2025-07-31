using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities.Carts;

namespace SilverCart.Infrastructure.FluentAPIs;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItems");

        // Properties
        builder.Property(ci => ci.Quantity)
            .IsRequired();

        builder.Property(ci => ci.Price)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(ci => ci.TotalPrice)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(ci => ci.IsSelected)
            .IsRequired()
            .HasDefaultValue(true);

        // Foreign keys
        builder.Property(ci => ci.CartId)
            .IsRequired();

        builder.Property(ci => ci.ProductId)
            .IsRequired();

        builder.Property(ci => ci.ProductItemId)
            .IsRequired();

        builder.Property(ci => ci.StoreId)
            .IsRequired();

        // Relationships
        builder.HasOne(ci => ci.Product)
            .WithMany()
            .HasForeignKey(ci => ci.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ci => ci.ProductItem)
            .WithMany()
            .HasForeignKey(ci => ci.ProductItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ci => ci.Store)
            .WithMany()
            .HasForeignKey(ci => ci.StoreId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}