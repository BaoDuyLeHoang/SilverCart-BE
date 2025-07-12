using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class PaymentConfiguration : IEntityTypeConfiguration<PaymentMethod>,
        IEntityTypeConfiguration<CustomerPaymentMethod>,
        IEntityTypeConfiguration<PaymentMethodHistory>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethods");
        }

        public void Configure(EntityTypeBuilder<CustomerPaymentMethod> builder)
        {
            builder.ToTable("CustomerPaymentMethods");
            builder.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId);
            builder.HasOne(x => x.PaymentMethod).WithMany().HasForeignKey(x => x.PaymentMethodId);
        }

        public void Configure(EntityTypeBuilder<PaymentMethodHistory> builder)
        {
            builder.ToTable("PaymentMethodHistories");
        }
    }
}