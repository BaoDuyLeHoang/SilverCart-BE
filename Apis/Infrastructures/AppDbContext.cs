using System.Reflection;
using Application.Commons;
using Application.Interfaces;
using Application.Utils;
using Domain.Common.Interfaces;
using Domain.Entities;
using Infrastructures.FluentAPIs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructures
{
    public class AppDbContext : DbContext
    {
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;
        private readonly AppConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options,
            ICurrentTime timeService,
            IClaimsService claimsService, AppConfiguration configuration) : base(options)
        {
            _timeService = timeService;
            _claimsService = claimsService;
            _configuration = configuration;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
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

        // Base entities
        public DbSet<BaseUser> Users { get; set; }
        public DbSet<BaseRole> Roles { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            // Fetch the current timestamp and user identifier (if any)
            var now = _timeService.GetCurrentTime();
            var userId = _claimsService.GetCurrentUserId;

            // Select entries that support IDateTracking
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is IDateTracking &&
                            (e.State == EntityState.Added ||
                             e.State == EntityState.Modified ||
                             e.State == EntityState.Deleted))
                .ToList();

            foreach (var entry in entries)
            {
                // Update IDateTracking fields
                if (entry.Entity is IDateTracking dateTracking)
                {
                    if (entry.State == EntityState.Added)
                    {
                        dateTracking.CreationDate = now;
                        dateTracking.ModificationDate = now;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        // Only update when a property value is modified
                        if (entry.Properties.Any(p => p.IsModified))
                        {
                            dateTracking.ModificationDate = now;
                        }
                    }
                    else if (entry.State == EntityState.Deleted)
                    {
                        dateTracking.DeletionDate = now;
                    }
                }

                // Update IUserTracking fields if there is a valid user identifier
                if (userId != null && entry.Entity is IUserTracking userTracking)
                {
                    if (entry.State == EntityState.Added)
                    {
                        userTracking.CreatedById = userId;
                        userTracking.ModificationById = userId;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        if (entry.Properties.Any(p => p.IsModified))
                        {
                            userTracking.ModificationById = userId;
                        }
                    }
                    else if (entry.State == EntityState.Deleted)
                    {
                        userTracking.DeleteById = userId;
                    }
                }

                // Convert physical deletion to soft deletion
                if (entry.Entity is BaseEntity baseEntity && entry.State == EntityState.Deleted)
                {
                    baseEntity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData(_configuration);
            base.OnModelCreating(modelBuilder);

            // Apply all other configurations from the assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}