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

namespace Infrastructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,
            AppConfiguration configuration)
        {

            AddRepositories(services);

            services.AddScoped<AuditInterceptor>();

            services.AddSingleton<ICurrentTime, CurrentTime>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<ISMSService, SMSService>();
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddHttpClient<IGhnService, GhnService>();
            services.AddSingleton<ILockingService, LockingService>();
            services.AddSingleton<ICalculateService, CalculateService>();
            services.AddSingleton<IGenerateQRCodeGeneratorService, GenerateQRCodeGeneratorService>();
            services.AddScoped<IRedisService, RedisService>();
            services.AddScoped<ILockingService, LockingService>();
            services.AddScoped<ICalculateService, CalculateService>();
            services.AddScoped<IGenerateQRCodeGeneratorService, GenerateQRCodeGeneratorService>();

            // Redis configuration
            services.AddSingleton<IConnectionMultiplexer>(sp =>
                ConnectionMultiplexer.Connect(configuration.RedisConnection ?? "localhost"));

            // Add Payments service to the container.
            services.AddSingleton<IVnpay, Vnpay>();
            // Add service that supports consultant users for call video...
            services.AddSingleton<IStringeeService, StringeeService>();

            // ATTENTION: if you do migration please check file README.md
            services.AddDbContext<AppDbContext>((service, option) =>
            {
                var auditInterceptor = service.GetService<AuditInterceptor>();
                option.UseNpgsql(configuration.DatabaseConnection);
                option.AddInterceptors(auditInterceptor);
            });

            // this configuration just use in-memory for fast develop
            //services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("test"));

            services.AddAutoMapper(typeof(UserMapperProfile).Assembly);

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
            services.AddScoped<IStoreAddressRepository, StoreAddressRepository>();
            services.AddScoped<ICustomerUserRepository, CustomerUserRepository>();
            services.AddScoped<IDependentUserRepository, DependentUserRepository>();
            services.AddScoped<IGuardianUserRepository, GuardianUserRepository>();
            services.AddScoped<IConversationRepository, ConversationRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IConsultationRepository, ConsultationRepository>();
            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
            services.AddScoped<IProductVariantRepository, ProductVariantsRepository>();
            services.AddScoped<IAdministratorUserRepository, AdministratorUserRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        //public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        //{
        //    // Add Kafka Settings
        //    services.Configure<KafkaSettings>(configuration.GetSection("Kafka"));

        //    // Register Kafka producer as singleton (recommended for Kafka producers)
        //    services.AddSingleton<IOrderMessageProducer, OrderMessageProducer>();

        //    return services;
        //}
    }
}
