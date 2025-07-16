using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CustomerRank>,
        IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerRank> builder)
        {
            builder.ToTable("CustomerRanks");
            builder.Property(cr => cr.Rank).IsRequired();
            builder.HasOne(cr => cr.Customer)
                   .WithMany()
                   .HasForeignKey(cr => cr.CustomerId);
        }

        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.ToTable("CustomerAddresses");
            builder.HasOne(ca => ca.Customer)
                   .WithMany()
                   .HasForeignKey(ca => ca.CustomerId);
            builder.HasOne(ca => ca.Address)
                   .WithMany()
                   .HasForeignKey(ca => ca.AddressId);

        }

    }
}