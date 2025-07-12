using SilverCart.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>,
        IEntityTypeConfiguration<UserPromotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.ToTable("Promotions");
        }

        public void Configure(EntityTypeBuilder<UserPromotion> builder)
        {
            builder.ToTable("UserPromotions");
        }
    }
}