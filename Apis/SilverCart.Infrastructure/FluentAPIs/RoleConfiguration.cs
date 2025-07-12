using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures.FluentAPIs
{
    public class RoleConfiguration : IEntityTypeConfiguration<AdministratorRole>,
        IEntityTypeConfiguration<ConsultantRole>
    {
        public void Configure(EntityTypeBuilder<AdministratorRole> builder)
        {
            builder.ToTable("AdministratorUserRoles");
        }

        public void Configure(EntityTypeBuilder<ConsultantRole> builder)
        {
            builder.ToTable("ConsultantRoles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RoleName).HasMaxLength(100);
        }
    }
}