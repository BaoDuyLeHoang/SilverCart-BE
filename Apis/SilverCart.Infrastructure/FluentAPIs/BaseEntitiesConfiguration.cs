using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Common.Interfaces;
using SilverCart.Domain.Commons.Entities;
using SilverCart.Domain.Entities;

namespace Infrastructures.FluentAPIs;

public class BaseEntitiesConfiguration : IEntityTypeConfiguration<BaseEntity>,
    IEntityTypeConfiguration<BaseUser>,
    IEntityTypeConfiguration<BaseRole>
{
    public void Configure(EntityTypeBuilder<BaseEntity> builder)
    {
        builder.UseTpcMappingStrategy();
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnOrder(0).ValueGeneratedNever();
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.HasQueryFilter(x => !x.IsDeleted);
        builder.Property(x => x.CreationDate).IsRequired(false).HasColumnOrder(95);
        builder.Property(x => x.CreatedById).IsRequired(false).HasColumnOrder(96);
        builder.Property(x => x.ModificationDate).IsRequired(false).HasColumnOrder(97);
        builder.Property(x => x.ModificationById).IsRequired(false).HasColumnOrder(98);
        builder.Property(x => x.DeletionDate).IsRequired(false).HasColumnOrder(99);
        builder.Property(x => x.DeleteById).IsRequired(false).HasColumnOrder(100);
    }


    public void Configure(EntityTypeBuilder<BaseUser> builder)
    {
        builder.Property(x => x.FullName).IsRequired();
    }


    public void Configure(EntityTypeBuilder<BaseRole> builder)
    {
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.NormalizedName).IsRequired(false);
        builder.Property(x => x.Description).IsRequired(false);
    }
}