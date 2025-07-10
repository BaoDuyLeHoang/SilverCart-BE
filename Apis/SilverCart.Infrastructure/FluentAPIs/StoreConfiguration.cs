using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>,
        IEntityTypeConfiguration<StoreRole>,
        IEntityTypeConfiguration<StoreUserRole>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Stores");
        }

        public void Configure(EntityTypeBuilder<StoreRole> builder)
        {
            builder.ToTable("StoreRoles");
        }

        public void Configure(EntityTypeBuilder<StoreUserRole> builder)
        {
            builder.ToTable("StoreUserRoles");
        }
    }
} 