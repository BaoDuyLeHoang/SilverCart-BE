using System.Reflection;
using SilverCart.Application.Commons;
using SilverCart.Application.Interfaces;
using SilverCart.Application.Utils;
using SilverCart.Domain.Common.Interfaces;
using SilverCart.Domain.Entities;
using Infrastructures.FluentAPIs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SilverCart.Domain.Commons.Entities;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Entities.Chat;

namespace Infrastructures
{
    public class AppDbContext : IdentityDbContext<BaseUser, BaseRole, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderReview> OrderReviews { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreUser> StoreUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CustomerPaymentMethod> CustomerPaymentMethods { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductPromotion> ProductPromotions { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<StoreRole> StoreRoles { get; set; }
        public DbSet<StoreUserRole> StoreUserRoles { get; set; }
        public DbSet<CustomerUser> CustomerUsers { get; set; }
        public DbSet<CustomerRank> CustomerRanks { get; set; }
        public DbSet<AdministratorUser> AdministratorUsers { get; set; }
        public DbSet<AdministratorRole> AdministratorUserRoles { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<UserReport> UserReports { get; set; }
        public DbSet<ProductReport> ProductReports { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<StockHistory> StockHistories { get; set; }
        public DbSet<PaymentMethodHistory> PaymentMethodHistories { get; set; }
        public DbSet<ScheduledTask> ScheduledTasks { get; set; }
        public DbSet<UserPromotion> UserPromotions { get; set; }
        public DbSet<StoreAddress> StoreAddresses { get; set; }
        public DbSet<GuardianUser> GuardianUsers { get; set; }
        public DbSet<DependentUser> DependentUsers { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }
        // Consultant
        public DbSet<Consultation> Consultants { get; set; }
        public DbSet<ConsultantUser> ConsultantUsers { get; set; }
        public DbSet<ConsultantRole> ConsultantRoles { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        // Base entities
        public DbSet<BaseUser> Users { get; set; }
        public DbSet<BaseRole> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure all enums as strings
            modelBuilder.ConvertAllEnumsToStrings();
            
            modelBuilder.Entity<Conversation>()
                    .HasOne(c => c.User1)
                    .WithMany(u => u.ConversationsAsUser1)
                    .HasForeignKey(c => c.User1Id)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Conversation>()
                .HasOne(c => c.User2)
                .WithMany(u => u.ConversationsAsUser2)
                .HasForeignKey(c => c.User2Id)
                .OnDelete(DeleteBehavior.Restrict);
            // Apply all other configurations from the assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}