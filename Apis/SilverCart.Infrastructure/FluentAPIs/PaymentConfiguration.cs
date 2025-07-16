using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Payments;

namespace Infrastructures.FluentAPIs
{
    public class PaymentConfiguration :
        IEntityTypeConfiguration<PaymentMethod>,
        IEntityTypeConfiguration<CustomerPaymentMethod>,
        IEntityTypeConfiguration<PaymentHistory>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethods");

            builder.HasMany(pm => pm.CustomerPaymentMethods)
                .WithOne(cpm => cpm.PaymentMethod)
                .HasForeignKey(cpm => cpm.PaymentMethodId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false); // Make the relationship optional

        }

        public void Configure(EntityTypeBuilder<CustomerPaymentMethod> builder)
        {
            builder.ToTable("CustomerPaymentMethods");

            // Configure relationships
            builder.HasOne(cpm => cpm.Customer)
                .WithMany(c => c.CustomerPaymentMethods)
                .HasForeignKey(cpm => cpm.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.HasOne(cpm => cpm.PaymentMethod)
                .WithMany(pm => pm.CustomerPaymentMethods)
                .HasForeignKey(cpm => cpm.PaymentMethodId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            // Configure properties
            builder.Property(cpm => cpm.IsDefault)
                .IsRequired()
                .HasDefaultValue(false);

        }

        public void Configure(EntityTypeBuilder<PaymentHistory> builder)
        {
            builder.ToTable("PaymentHistories");

            // Configure other relationships
            builder.HasOne(ph => ph.CustomerUser)
                .WithMany(cu => cu.PaymentHistories)
                .HasForeignKey(ph => ph.CustomerUserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne(ph => ph.PaymentMethod)
                .WithMany(pm => pm.PaymentHistories)
                .HasForeignKey(ph => ph.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne(ph => ph.Order)
                .WithMany()
                .HasForeignKey(ph => ph.OrderId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne(ph => ph.Promotion)
                .WithMany()
                .HasForeignKey(ph => ph.PromotionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne(ph => ph.Wallet)
                .WithMany(w => w.PaymentHistories)
                .HasForeignKey(ph => ph.WalletId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

        }
    }
}