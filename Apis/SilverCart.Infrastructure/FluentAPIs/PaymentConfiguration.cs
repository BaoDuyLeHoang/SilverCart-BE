using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Payments;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures.FluentAPIs
{
    public class PaymentConfiguration :
        IEntityTypeConfiguration<PaymentMethod>,
        IEntityTypeConfiguration<CustomerPaymentMethod>,
        IEntityTypeConfiguration<PaymentHistory>,
        IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethods");

            builder.HasMany(pm => pm.CustomerPaymentMethods)
                .WithOne(cpm => cpm.PaymentMethod)
                .HasForeignKey(cpm => cpm.PaymentMethodId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false); // Make the relationship optional
            builder.HasData([
                new PaymentMethod
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    Name = "VNPay",
                    Description = "Thanh toán qua VNPay",
                    IconPath = "/images/payment/vnpay-icon.png",
                    IsActive = true,
                    Order = 1,
                },
                new PaymentMethod
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    Name = "Tiền Mặt",
                    Description = "Thanh toán qua tiền mặt",
                    IconPath = "/images/payment/cash-icon.png",
                    IsActive = true,
                    Order = 2,
                }
            ]);

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
            builder.HasOne(ph => ph.User)
                .WithMany()
                .HasForeignKey(ph => ph.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasOne(ph => ph.PaymentMethod)
                .WithMany(pm => pm.PaymentHistories)
                .HasForeignKey(ph => ph.PaymentMethodId)
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

        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.ToTable("Wallets");

            builder.HasOne(w => w.User)
                .WithOne()
                .HasForeignKey<Wallet>(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(w => w.PaymentHistories)
                .WithOne(ph => ph.Wallet)
                .HasForeignKey(ph => ph.WalletId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}