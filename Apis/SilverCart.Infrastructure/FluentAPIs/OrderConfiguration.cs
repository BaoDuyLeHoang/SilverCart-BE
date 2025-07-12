using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>,
        IEntityTypeConfiguration<OrderStatus>,
        IEntityTypeConfiguration<OrderReview>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
        }

        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.ToTable("OrderStatuses");
        }

        public void Configure(EntityTypeBuilder<OrderReview> builder)
        {
            builder.ToTable("OrderReviews");
        }
    }
}