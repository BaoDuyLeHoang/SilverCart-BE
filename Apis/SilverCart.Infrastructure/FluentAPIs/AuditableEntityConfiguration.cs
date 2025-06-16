using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Common.Interfaces;

namespace Infrastructures.FluentAPIs;

public class AuditableEntityConfiguration<T> : IEntityTypeConfiguration<T>
    where T : class, IBaseEntity, IAuditableEntity
{
    //probably only use for Identity class
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.HasQueryFilter(x => !x.IsDeleted);
        builder.Property(x => x.CreationDate).IsRequired(false).HasColumnOrder(95);
        builder.Property(x => x.CreatedById).IsRequired(false).HasColumnOrder(96);
        builder.Property(x => x.ModificationDate).IsRequired(false).HasColumnOrder(97);
        builder.Property(x => x.ModificationById).IsRequired(false).HasColumnOrder(98);
        builder.Property(x => x.DeletionDate).IsRequired(false).HasColumnOrder(99);
        builder.Property(x => x.DeleteById).IsRequired(false).HasColumnOrder(100);
    }
}