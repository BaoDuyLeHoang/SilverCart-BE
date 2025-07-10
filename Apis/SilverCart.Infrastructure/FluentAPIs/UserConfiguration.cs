using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Enums;
using Microsoft.AspNetCore.Identity;

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
            
            builder.HasData(new AdministratorUser
            {
                Id = Guid.Parse("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                FullName = "Super Admin",
                Email = "admin@elderly.com",
                NormalizedEmail = "ADMIN@ELDERLY.COM",
                UserName = "superadmin",
                NormalizedUserName = "SUPERADMIN",
                PasswordHash = new PasswordHasher<AdministratorUser>().HashPassword(null!, "SuperAdmin123!"),
                EmailConfirmed = true,
                IsDeleted = false,
                CreationDate = DateTime.UtcNow
            });
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
                .HasForeignKey(x => x.ConsultantId)
                .OnDelete(DeleteBehavior.Restrict);

        }

        public void Configure(EntityTypeBuilder<Consultation> builder)
        {
            builder.ToTable("Consultations");


            builder.HasOne(x => x.ConsultantUser)
                .WithMany(x => x.Consultations)
                .HasForeignKey(x => x.ConsultantId);

            builder.HasOne(x => x.DependentUser)
                .WithMany()  // assuming not bi-directional
                .HasForeignKey(x => x.CustomerId);
        }
        public void Configure(EntityTypeBuilder<ConsultantRole> builder)
        {
            builder.ToTable("ConsultantRoles");
            builder.HasKey(x => x.Id); // ✅ Explicitly set primary key
            builder.Property(x => x.RoleName).HasMaxLength(100);
        }
    }
}