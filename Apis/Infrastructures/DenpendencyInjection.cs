using Application;
using Application.Interfaces;
using Application.Repositories;
using Application.Services;
using Infrastructures.Mappers;
using Infrastructures.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Infrastructures
{
    public static class DenpendencyInjection
    {
        public static IServiceCollection AddInfrastructuresService(this IServiceCollection services,
            string databaseConnection)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<ICurrentTime, CurrentTime>();
            services.AddSingleton<IEmailService, EmailService>();

            // ATTENTION: if you do migration please check file README.md
            services.AddDbContext<AppDbContext>(option => option.UseNpgsql(databaseConnection));

            // this configuration just use in-memory for fast develop
            //services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("test"));

            services.AddAutoMapper(typeof(MapperConfigurationsProfile).Assembly);

            return services;
        }

        // public static IServiceCollection AddSeriLogConfiguration(this IServiceCollection services,
        //     IConfiguration configuration)
        // {
        //     var logger = new LoggerConfiguration()
        //         .ReadFrom.Configuration(configuration)
        //         .Enrich.FromLogContext()
        //         .CreateLogger();
        //
        //     Log.Logger = logger;
        //
        //     services.AddLogging(loggingBuilder =>
        //         loggingBuilder.AddSerilog(Log.Logger, dispose: true));
        //
        //     return services;
        // }
    }
}