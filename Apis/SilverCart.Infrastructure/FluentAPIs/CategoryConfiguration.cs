using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasOne(x => x.ParentCategory).WithMany(x => x.SubCategories);
            builder.HasOne(x => x.ApprovedUser);
            builder.HasMany(x => x.ProductCategories).WithOne(x => x.Category);
        }
    }
}