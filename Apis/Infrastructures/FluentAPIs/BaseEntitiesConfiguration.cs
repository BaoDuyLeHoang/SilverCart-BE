using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs;

public class BaseEntitiesConfiguration : IEntityTypeConfiguration<BaseFullEntity>
    , IEntityTypeConfiguration<BaseEntity>,
    IEntityTypeConfiguration<BaseUser>,
    IEntityTypeConfiguration<BaseRole>
{
    public void Configure(EntityTypeBuilder<BaseEntity> builder)
    {
        builder.UseTpcMappingStrategy();
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasColumnOrder(0).ValueGeneratedOnAdd();

        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.HasQueryFilter(x => !x.IsDeleted);
    }
    public void Configure(EntityTypeBuilder<BaseFullEntity> builder)
    {
        builder.Property(x => x.CreationDate).IsRequired(false).HasColumnOrder(95);
        builder.Property(x => x.CreatedById).IsRequired(false).HasColumnOrder(96);
        builder.Property(x => x.ModificationDate).IsRequired(false).HasColumnOrder(97);
        builder.Property(x => x.ModificationById).IsRequired(false).HasColumnOrder(98);
        builder.Property(x => x.DeletionDate).IsRequired(false).HasColumnOrder(99);
        builder.Property(x => x.DeleteById).IsRequired(false).HasColumnOrder(100);
    }



    public void Configure(EntityTypeBuilder<BaseUser> builder)
    {
        builder.Property(x => x.FirstName).IsRequired();
        builder.Property(x => x.LastName).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Phone).IsRequired(false);
        builder.Property(x => x.PasswordHash).IsRequired();
        builder.Property(x => x.IsVerified).HasDefaultValue(true);
    }


    public void Configure(EntityTypeBuilder<BaseRole> builder)
    {
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.NormalizedName).IsRequired(false);
        builder.Property(x => x.Description).IsRequired(false);
    }
}