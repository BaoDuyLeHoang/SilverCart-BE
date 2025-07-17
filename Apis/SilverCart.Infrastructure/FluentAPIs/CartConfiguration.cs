using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities.Cart;

namespace Infrastructures.FluentAPIs
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>, IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");
        }

        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItem");
        }
    }
}