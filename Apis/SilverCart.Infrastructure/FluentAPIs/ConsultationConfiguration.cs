using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class ConsultationConfiguration : IEntityTypeConfiguration<Consultation>
    {
        public void Configure(EntityTypeBuilder<Consultation> builder)
        {
            builder.ToTable("Consultations");

            builder.HasOne(x => x.ConsultantUser)
                .WithMany(x => x.Consultations)
                .HasForeignKey(x => x.ConsultantId);

            builder.HasOne(x => x.DependentUser)
                .WithMany()
                .HasForeignKey(x => x.CustomerId);
        }
    }
}