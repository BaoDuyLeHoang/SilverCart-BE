using System.Runtime.CompilerServices;
using Core.Interfaces;
using Infrastructures.Interfaces;
using Infrastructures.Interfaces.Entities;
using SilverCart.Application.Interfaces;
using SilverCart.Application.Repositories;
using SilverCart.Application.Services;
using SilverCart.Application.Utils;
using Infrastructures.Mappers;
using Infrastructures.Repositories;
using Infrastructures.Services.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SilverCart.Domain.Commons.Entities;
using SilverCart.Domain.Entities;
using VNPAY.NET;
using Infrastructures.Interfaces.System;
using Infrastructures.Interfaces.Repositories;
using Infrastructures.Services.System;
using StackExchange.Redis;
using SilverCart.Application.Interfaces.System;
using SilverCart.Infrastructure.Commons;
using SilverCart.Application.Services.System;
using SilverCart.Application.Features.Orders.Queries.Shipping.CalculateShippingFee;
using SilverCart.Application.Interfaces.Repositories;

namespace Infrastructures
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection services,
            AppConfiguration configuration)
        {
            AddRepositories(services);

            // Add StoreSettings configuration
            services.AddScoped<AuditInterceptor>();
            // ATTENTION: if you do migration please check file README.md
            services.AddDbContext<AppDbContext>((service, option) =>
            {
                var auditInterceptor = service.GetService<AuditInterceptor>();
                option.UseNpgsql(configuration.DatabaseConnection);
                option.AddInterceptors(auditInterceptor);
            });
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.AddAutoMapper(assemblies);
            // services.AddAutoMapper(typeof(UserMapperProfile).Assembly);
            // services.AddAutoMapper(typeof(CalculateShippingFeeMapper).Assembly);

            services.AddIdentity<BaseUser, BaseRole>(options =>
                {
                    // configure password, lockout, etc. if needed
                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Add Authentication jwt
            return services;
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOTPRepository, OTPRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IConsultantUserRepository, ConsultantUserRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IStoreUserRepository, StoreUserRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductItemRepository, ProductItemRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<IStoreAddressRepository, StoreAddressRepository>();
            services.AddScoped<ICustomerUserRepository, CustomerUserRepository>();
            services.AddScoped<IDependentUserRepository, DependentUserRepository>();
            services.AddScoped<IGuardianUserRepository, GuardianUserRepository>();
            services.AddScoped<IConversationRepository, ConversationRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IConsultationRepository, ConsultationRepository>();
            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IPaymentHistoryRepository, PaymentHistoryRepository>();
            services.AddScoped<IAdministratorUserRepository, AdministratorUserRepository>();
            services.AddScoped<IUserPromotionRepository, UserPromotionRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IPromotionRepository, PromotionRepository>();
        }
    }
}