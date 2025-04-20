using System.Runtime.CompilerServices;
using Application;
using Application.Interfaces;
using Application.Repositories;
using Application.Services;
using Application.Utils;
using Infrastructures.Mappers;
using Infrastructures.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Infrastructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructuresService(this IServiceCollection services,
            string databaseConnection)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            
            services.AddSingleton<ICurrentTime, CurrentTime>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<ISMSService, SMSService>();

            // ATTENTION: if you do migration please check file README.md
            services.AddDbContext<AppDbContext>(option => option.UseNpgsql(databaseConnection));

            // this configuration just use in-memory for fast develop
            //services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("test"));

            services.AddAutoMapper(typeof(CommonMapperProfile).Assembly, typeof(UserMapperProfile).Assembly);

            // Add Authentication jwt
            return services;
        }
    }
}