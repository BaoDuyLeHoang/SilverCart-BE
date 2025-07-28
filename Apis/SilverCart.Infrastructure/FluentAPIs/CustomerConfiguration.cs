using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CustomerRank>
    {
        public void Configure(EntityTypeBuilder<CustomerRank> builder)
        {
            builder.ToTable("CustomerRanks");
            builder.Property(cr => cr.Rank).IsRequired();
            builder.HasOne(cr => cr.Customer)
                   .WithMany()
                   .HasForeignKey(cr => cr.CustomerId);
        }
    }
}