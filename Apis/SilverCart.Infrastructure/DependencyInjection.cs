using System.Runtime.CompilerServices;
using Infrastructures.Interfaces.Entities;
using SilverCart.Application;
using SilverCart.Application.Interfaces;
using SilverCart.Application.Repositories;
using SilverCart.Application.Services;
using SilverCart.Application.Utils;
using Infrastructures.Mappers;
using Infrastructures.Repositories;
using Infrastructures.Services.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SilverCart.Domain.Commons.Entities;
using SilverCart.Domain.Entities;
using VNPAY.NET;
using Infrastructures.Interfaces.System;
using Infrastructures.Interfaces.Repositories;
using Infrastructures.Services.System;
using SilverCart.Application.Features.Orders.Integration;
using SilverCart.Infrastructure.Integration.Kafka;

namespace Infrastructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,
            string databaseConnection)
        {
            #region Entity Service & Repository

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IConsultantUserRepository, ConsultantUserRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IStoreUserRepository, StoreUserRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductItemRepository, ProductItemRepository>();
            services.AddScoped<IStoreProductItemRepository, StoreProductItemRepository>();
            services.AddScoped<IStoreAddressRepository, StoreAddressRepository>();
            services.AddScoped<ICustomerUserRepository, CustomerUserRepository>();
            services.AddScoped<IDependentUserRepository, DependentUserRepository>();
            services.AddScoped<IGuardianUserRepository, GuardianUserRepository>();
            services.AddScoped<IConversationRepository, ConversationRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
<<<<<<< HEAD
            services.AddScoped<IStoreOrderRepository, StoreOrderRepository>();
            services.AddScoped<IStoreProductItemOrderRepository, StoreProductItemOrderRepository>();
=======
            services.AddScoped<IConsultantUserRepository, ConsultantUserRepository>();
            services.AddScoped<IConsultationRepository, ConsultationRepository>();
>>>>>>> 8f1555a34ed75f6ac7854bab98b248deb8824077
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            services.AddScoped<AuditInterceptor>();

            services.AddSingleton<ICurrentTime, CurrentTime>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<ISMSService, SMSService>();
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddHttpClient<IGhnService, GhnService>();
            services.AddSingleton<ILockingService, LockingService>();
            services.AddSingleton<ICalculateService, CalculateService>();
<<<<<<< HEAD
            services.AddSingleton<IGenerateQRCodeGeneratorService, GenerateQRCodeGeneratorService>();

=======
>>>>>>> 8f1555a34ed75f6ac7854bab98b248deb8824077
            // Add Payments service to the container.
            services.AddSingleton<IVnpay, Vnpay>();
            // Add service that supports consultant users for call video...
            services.AddSingleton<IStringeeService, StringeeService>();

            // ATTENTION: if you do migration please check file README.md
            services.AddDbContext<AppDbContext>((service, option) =>
            {
                var auditInterceptor = service.GetService<AuditInterceptor>();
                option.UseNpgsql(databaseConnection);
                option.AddInterceptors(auditInterceptor);
            });

            // this configuration just use in-memory for fast develop
            //services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("test"));

            services.AddAutoMapper(typeof(UserMapperProfile).Assembly);

            #region Identity

            services.AddIdentity<BaseUser, BaseRole>(options =>
                {
                    // configure password, lockout, etc. if needed
                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            #endregion

            // Add Authentication jwt
            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add Kafka Settings
            services.Configure<KafkaSettings>(configuration.GetSection("Kafka"));

            // Register Kafka producer as singleton (recommended for Kafka producers)
            services.AddSingleton<IOrderMessageProducer, OrderMessageProducer>();

            return services;
        }
    }
}