using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>,
        IEntityTypeConfiguration<UserReport>,
        IEntityTypeConfiguration<ProductReport>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Reports");
        }

        public void Configure(EntityTypeBuilder<UserReport> builder)
        {
            builder.ToTable("UserReports");
        }

        public void Configure(EntityTypeBuilder<ProductReport> builder)
        {
            builder.ToTable("ProductReports");
        }
    }
} 