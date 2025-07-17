using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Enums;
using System.Reflection.Emit;

namespace Infrastructures.FluentAPIs
{
    public class UserConfiguration : IEntityTypeConfiguration<BaseUser>,
        IEntityTypeConfiguration<CustomerUser>,
        IEntityTypeConfiguration<StoreUser>,
        IEntityTypeConfiguration<AdministratorUser>,
        IEntityTypeConfiguration<GuardianUser>,
        IEntityTypeConfiguration<DependentUser>,
        IEntityTypeConfiguration<ConsultantUser>
    {
        public void Configure(EntityTypeBuilder<BaseUser> builder)
        {
            builder.ToTable("AspNetUsers");
            // Removed OTP relationship
        }

        public void Configure(EntityTypeBuilder<CustomerUser> builder)
        {
            builder.ToTable("CustomerUsers");
            builder.HasOne(x => x.Rank)
                .WithOne(x => x.Customer)
                .HasForeignKey<CustomerRank>(x => x.CustomerId);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.CustomerUser)
                .HasForeignKey(x => x.CustomerUserId);
        }

        public void Configure(EntityTypeBuilder<StoreUser> builder)
        {
            builder.ToTable("StoreUsers");
        }

        public void Configure(EntityTypeBuilder<AdministratorUser> builder)
        {
            builder.ToTable("AdministratorUsers");
        }

        public void Configure(EntityTypeBuilder<DependentUser> builder)
        {
            builder.ToTable("DependentUsers");
            builder.HasOne(x => x.Guardian).WithMany(x => x.Dependents).HasForeignKey(x => x.GuardianId);
        }

        public void Configure(EntityTypeBuilder<GuardianUser> builder)
        {
            builder.ToTable("GuardianUsers");
            builder.HasMany(x => x.Dependents).WithOne(x => x.Guardian).HasForeignKey(x => x.GuardianId);
        }

        public void Configure(EntityTypeBuilder<ConsultantUser> builder)
        {
            builder.ToTable("ConsultantUsers");
            builder.HasMany(x => x.Consultations)
                .WithOne(x => x.ConsultantUser)
                .HasForeignKey(x => x.ConsultantId);
        }
    }
}