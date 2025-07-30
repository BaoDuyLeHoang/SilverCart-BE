using FluentValidation;
using Infrastructures.Commons.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using SilverCart.Application.Interfaces;
using SilverCart.Application.Services.System;
using SilverCart.Application.Services;
using SilverCart.Application.Interfaces.System;
using Infrastructures.Interfaces.System;
using Infrastructures.Services.System;
using Infrastructures.Services.Entities;
using VNPAY.NET;
using Core.Interfaces;
using SilverCart.Infrastructure.Commons;
using SilverCart.Application.Features.Orders.Queries.Shipping.CalculateShippingFee;

namespace Infrastructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services, AppConfiguration configuration)
        {
            services.AddValidatorsFromAssemblies([AssemblyReference.Executing]);
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>),
                            ServiceLifetime.Scoped);
            });

            services.AddScoped<ICurrentTime, CurrentTime>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ISMSService, SMSService>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IGhnService, GhnService>();
            services.AddScoped<IGenerateQRCodeGeneratorService, GenerateQRCodeGeneratorService>();
            services.AddScoped<IRedisService, RedisService>();
            services.AddScoped<IFirebaseFileService, FirebaseFileService>();

            // Configure Redis
            services.AddSingleton<IConnectionMultiplexer>(sp =>
                ConnectionMultiplexer.Connect(new ConfigurationOptions
                {
                    EndPoints = { configuration.RedisConnection },
                    AbortOnConnectFail = false,
                    ConnectTimeout = 5000,
                    SyncTimeout = 5000,
                    ResponseTimeout = 5000,
                    Password = configuration.RedisPassword,
                    Ssl = false
                }, log: Console.Out));

            // Add Payments service to the container.
            services.AddSingleton<IVnpay, Vnpay>();
            // Add service that supports consultant users for call video...
            services.AddSingleton<IStringeeService, StringeeService>();




            return services;
        }
    }
}
