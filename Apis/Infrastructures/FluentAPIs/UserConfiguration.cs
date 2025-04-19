using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class UserConfiguration : IEntityTypeConfiguration<CustomerUser>,
        IEntityTypeConfiguration<Product>,
        IEntityTypeConfiguration<ProductVariant>,
        IEntityTypeConfiguration<ProductItem>,
        IEntityTypeConfiguration<ProductImage>,
        IEntityTypeConfiguration<Order>,
        IEntityTypeConfiguration<OrderItem>,
        IEntityTypeConfiguration<OrderStatus>,
        IEntityTypeConfiguration<OrderReview>,
        IEntityTypeConfiguration<PaymentMethod>,
        IEntityTypeConfiguration<Category>,
        IEntityTypeConfiguration<Store>,
        IEntityTypeConfiguration<StoreUser>,
        IEntityTypeConfiguration<Address>,
        IEntityTypeConfiguration<CustomerPaymentMethod>,
        IEntityTypeConfiguration<CartItem>,
        IEntityTypeConfiguration<Cart>,
        IEntityTypeConfiguration<ProductPromotion>,
        IEntityTypeConfiguration<Promotion>,
        IEntityTypeConfiguration<StoreRole>,
        IEntityTypeConfiguration<StoreUserRole>,
        IEntityTypeConfiguration<CustomerRank>,
        IEntityTypeConfiguration<AdministratorUser>,
        IEntityTypeConfiguration<AdministratorRole>,
        IEntityTypeConfiguration<Report>,
        IEntityTypeConfiguration<UserReport>,
        IEntityTypeConfiguration<ProductReport>,
        IEntityTypeConfiguration<CustomerAddress>,
        IEntityTypeConfiguration<StockHistory>,
        IEntityTypeConfiguration<PaymentMethodHistory>,
        IEntityTypeConfiguration<ScheduledTask>,
        IEntityTypeConfiguration<UserPromotion>
    {
        public void Configure(EntityTypeBuilder<CustomerUser> builder)
        {
            builder.ToTable("CustomerUsers");
            builder.HasOne(x => x.Rank)
                .WithOne(x => x.Customer)
                .HasForeignKey<CustomerRank>(x => x.CustomerId);
            // .OnDelete(DeleteBehavior.Cascade);
            builder.OwnsOne(x => x.OTP);
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
        }

        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.ToTable("ProductVariants");
        }

        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.ToTable("ProductItems");
        }

        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");
        }

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
        }

        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
        }

        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.ToTable("OrderStatuses");
        }

        public void Configure(EntityTypeBuilder<OrderReview> builder)
        {
            builder.ToTable("OrderReviews");
        }

        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethods");
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
        }

        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Stores");
        }

        public void Configure(EntityTypeBuilder<StoreUser> builder)
        {
            builder.ToTable("StoreUsers");
            builder.OwnsOne(x => x.OTP);
        }

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
        }

        public void Configure(EntityTypeBuilder<CustomerPaymentMethod> builder)
        {
            builder.ToTable("CustomerPaymentMethods");
            builder.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId);
            builder.HasOne(x => x.PaymentMethod).WithMany().HasForeignKey(x => x.PaymentMethodId);
        }

        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItem");
        }

        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");
        }

        public void Configure(EntityTypeBuilder<ProductPromotion> builder)
        {
            builder.ToTable("ProductPromotions");
            builder.HasOne(x => x.Product).WithMany(x => x.ProductPromotions).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Promotion).WithMany(x => x.ProductPromotions).HasForeignKey(x => x.PromotionId);
        }

        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.ToTable("Promotions");
        }

        public void Configure(EntityTypeBuilder<StoreRole> builder)
        {
            builder.ToTable("StoreRoles");
        }

        public void Configure(EntityTypeBuilder<StoreUserRole> builder)
        {
            builder.ToTable("StoreUserRoles");
        }

        public void Configure(EntityTypeBuilder<CustomerRank> builder)
        {
            builder.ToTable("CustomerRanks");
        }

        public void Configure(EntityTypeBuilder<AdministratorUser> builder)
        {
            builder.ToTable("AdministratorUsers");
            builder.OwnsOne(x => x.OTP);
        }

        public void Configure(EntityTypeBuilder<AdministratorRole> builder)
        {
            builder.ToTable("AdministratorUserRoles");
        }

        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Reports");
        }

        public void Configure(EntityTypeBuilder<UserReport> builder)
        {
            builder.ToTable("UserReports");
        }

        public void Configure(EntityTypeBuilder<ProductReport> builder)
        {
            builder.ToTable("ProductReports");
        }

        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.ToTable("CustomerAddresses");
        }

        public void Configure(EntityTypeBuilder<StockHistory> builder)
        {
            builder.ToTable("StockHistories");
        }

        public void Configure(EntityTypeBuilder<PaymentMethodHistory> builder)
        {
            builder.ToTable("PaymentMethodHistories");
        }

        public void Configure(EntityTypeBuilder<ScheduledTask> builder)
        {
            builder.ToTable("ScheduledTasks");
        }

        public void Configure(EntityTypeBuilder<UserPromotion> builder)
        {
            builder.ToTable("UserPromotions");
        }
    }
}