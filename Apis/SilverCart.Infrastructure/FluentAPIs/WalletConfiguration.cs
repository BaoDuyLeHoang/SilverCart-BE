using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities.Auth;

public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.ToTable("Wallets");
        builder.Property(w => w.Balance).IsRequired();
        builder.Property(w => w.Points).IsRequired();
        builder.HasMany(w => w.PaymentHistories)
               .WithOne(ph => ph.Wallet)
               .HasForeignKey(ph => ph.WalletId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}