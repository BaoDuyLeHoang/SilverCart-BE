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

            builder.HasOne(o => o.ConfirmUser)
                .WithMany()
                .HasForeignKey(o => o.ConfirmUserId)
                .IsRequired(false);
            builder.HasOne(o => o.OrderedUser)
                .WithMany()
                .HasForeignKey(o => o.OrderedUserId)
                .IsRequired(false);
            builder.HasOne(o => o.RecieveUser)
                .WithMany()
                .HasForeignKey(o => o.RecieveUserId)
                .IsRequired(false);
        }

        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.ToTable("OrderStatuses");
            builder.Property(x => x.Status).HasConversion<string>();

        }
    }
}
