using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructures.FluentAPIs
{
    public class UserConfiguration : IEntityTypeConfiguration<BaseUser>, IEntityTypeConfiguration<CustomerUser>,
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
        IEntityTypeConfiguration<AdministratorUserRole>,
        IEntityTypeConfiguration<Report>,
        IEntityTypeConfiguration<UserReport>,
        IEntityTypeConfiguration<ProductReport>,
        IEntityTypeConfiguration<CustomerAddress>,
        IEntityTypeConfiguration<StockHistory>,
        IEntityTypeConfiguration<PaymentMethodHistory>,
        IEntityTypeConfiguration<ScheduledTask>,
        IEntityTypeConfiguration<UserPromotion>
    {
        public void Configure(EntityTypeBuilder<BaseUser> builder)
        {
            builder.Property(x => x.Email).HasMaxLength(100);
        }

        public void Configure(EntityTypeBuilder<CustomerUser> builder)
        {
            builder.HasOne(x => x.Rank)
                .WithOne(x => x.Customer)
                .HasForeignKey<CustomerRank>(x => x.CustomerId);
            // .OnDelete(DeleteBehavior.Cascade);
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
        }

        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.ToTable("ProductVariant");
        }

        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.ToTable("ProductItem");
        }

        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImage");
        }

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
        }

        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");
        }

        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.ToTable("OrderStatus");
        }

        public void Configure(EntityTypeBuilder<OrderReview> builder)
        {
            builder.ToTable("OrderReview");
        }

        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethod");
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
        }

        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Store");
        }

        public void Configure(EntityTypeBuilder<StoreUser> builder)
        {
            builder.ToTable("StoreUser");
        }

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
        }

        public void Configure(EntityTypeBuilder<CustomerPaymentMethod> builder)
        {
            builder.ToTable("CustomerPaymentMethod");
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
            builder.ToTable("ProductPromotion");
        }

        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.ToTable("Promotion");
        }

        public void Configure(EntityTypeBuilder<StoreRole> builder)
        {
            builder.ToTable("StoreRole");
        }

        public void Configure(EntityTypeBuilder<StoreUserRole> builder)
        {
            builder.ToTable("StoreUserRole");
        }

        public void Configure(EntityTypeBuilder<CustomerRank> builder)
        {
            builder.ToTable("CustomerRank");
        }

        public void Configure(EntityTypeBuilder<AdministratorUser> builder)
        {
            builder.ToTable("AdministratorUser");
        }

        public void Configure(EntityTypeBuilder<AdministratorUserRole> builder)
        {
            builder.ToTable("AdministratorUserRole");
        }

        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Report");
        }

        public void Configure(EntityTypeBuilder<UserReport> builder)
        {
            builder.ToTable("UserReport");
        }

        public void Configure(EntityTypeBuilder<ProductReport> builder)
        {
            builder.ToTable("ProductReport");
        }

        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.ToTable("CustomerAddress");
        }

        public void Configure(EntityTypeBuilder<StockHistory> builder)
        {
            builder.ToTable("StockHistory");
        }

        public void Configure(EntityTypeBuilder<PaymentMethodHistory> builder)
        {
            builder.ToTable("PaymentMethodHistory");
        }

        public void Configure(EntityTypeBuilder<ScheduledTask> builder)
        {
            builder.ToTable("ScheduledTask");
        }

        public void Configure(EntityTypeBuilder<UserPromotion> builder)
        {
            builder.ToTable("UserPromotion");
        }
    }
}