using System.Reflection;

using SilverCart.Application.Interfaces;
using SilverCart.Application.Utils;
using SilverCart.Domain.Common.Interfaces;
using SilverCart.Domain.Entities;
using Infrastructures.FluentAPIs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SilverCart.Domain.Commons.Entities;
using SilverCart.Domain.Entities.Orders;
using SilverCart.Domain.Entities.Products;
using SilverCart.Domain.Entities.Payments;
using SilverCart.Domain.Entities.Categories;
using SilverCart.Domain.Entities.Stores;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Entities.Carts;
using SilverCart.Domain.Entities.Stocks;
using SilverCart.Domain.Entities.Chat;
using SilverCart.Domain.Entities.Promotions;

namespace Infrastructures
{
    public class AppDbContext : IdentityDbContext<BaseUser, BaseRole, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<ConversationMember> ConversationMembers { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentHistory> PaymentHistories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreUser> StoreUsers { get; set; }
        public DbSet<StoreUserRole> StoreUserRoles { get; set; }
        public DbSet<SavedAddress> Addresses { get; set; }
        public DbSet<CustomerPaymentMethod> CustomerPaymentMethods { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductPromotion> ProductPromotions { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<StoreRole> StoreRoles { get; set; }
        public DbSet<CustomerUser> CustomerUsers { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<AdministratorUser> AdministratorUsers { get; set; }
        public DbSet<AdministratorRole> AdministratorUserRoles { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<UserReport> UserReports { get; set; }
        public DbSet<ProductReport> ProductReports { get; set; }
        public DbSet<StockHistory> StockHistories { get; set; }
        public DbSet<UserPromotion> UserPromotions { get; set; }
        public DbSet<StoreAddress> StoreAddresses { get; set; }
        public DbSet<GuardianUser> GuardianUsers { get; set; }
        public DbSet<DependentUser> DependentUsers { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }
        // Consultant
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<ConsultantUser> ConsultantUsers { get; set; }
        public DbSet<ConsultantRole> ConsultantRoles { get; set; }
        public new DbSet<BaseUser> Users { get; set; }
        public new DbSet<BaseRole> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure all enums as strings
            modelBuilder.ConvertAllEnumsToStrings();

            // Apply all other configurations from the assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Cấu hình connection resiliency để tránh deadlock
            optionsBuilder.EnableSensitiveDataLogging(false);
            optionsBuilder.EnableDetailedErrors(false);
        }
    }

}