using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities.Orders;

namespace Infrastructures.FluentAPIs
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>, IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasOne(o => o.ShippingStatus).WithOne().HasForeignKey<OrderShippingStatus>(o => o.Id);
            builder.HasOne(o => o.PaymentStatus).WithOne().HasForeignKey<OrderPaymentStatus>(o => o.Id);
            builder.HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId);

            builder.HasOne(o => o.ConfirmUser);
            builder.HasOne(o => o.OrderedUser);
            builder.HasOne(o => o.RecieveUser);
        }

        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.ToTable("OrderStatuses");
            builder.Property(x => x.Status).HasConversion<string>();

        }
    }
}
