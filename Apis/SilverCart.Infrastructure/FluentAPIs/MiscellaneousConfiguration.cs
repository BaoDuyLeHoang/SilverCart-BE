using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class MiscellaneousConfiguration : IEntityTypeConfiguration<Address>,
        IEntityTypeConfiguration<StockHistory>,
        IEntityTypeConfiguration<ScheduledTask>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
        }

        public void Configure(EntityTypeBuilder<StockHistory> builder)
        {
            builder.ToTable("StockHistories");
        }

        public void Configure(EntityTypeBuilder<ScheduledTask> builder)
        {
            builder.ToTable("ScheduledTasks");
        }
    }
}