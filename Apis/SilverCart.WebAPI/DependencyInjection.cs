using FluentValidation.AspNetCore;
using System.Diagnostics;
//using Infrastructures.Swaggers.Examples;
using Microsoft.OpenApi.Models;
using SilverCart.Application.Interfaces;
using Swashbuckle.AspNetCore.Filters;
using WebAPI.Filters;
using WebAPI.Middlewares;
using WebAPI.Services;
using WebAPI.SilverCart.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Infrastructures;

namespace WebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ResponseMappingFilter>();
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHealthChecks();
            services.AddApplicationDI();
            services.AddSingleton<GlobalExceptionMiddleware>();
            services.AddSingleton<PerformanceMiddleware>();
            services.AddSingleton<Stopwatch>();
            services.AddScoped<IClaimsService, ClaimsService>();
            services.AddHttpContextAccessor();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            return services;
        }

        public static IServiceCollection AddSwaggerGeneration(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"])),
                    ClockSkew = TimeSpan.FromSeconds(1)

                };
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        context.HandleResponse();

                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";
                        var result = Newtonsoft.Json.JsonConvert.SerializeObject(new
                        {
                            message = "You need to log in to access this resource."
                        });
                        return context.Response.WriteAsync(result);
                    }
                };
            });
            //services.AddSwaggerExamplesFromAssemblyOf<LoginRequestSuperAdminExample>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FOV API", Version = "v1" });
                c.EnableAnnotations();
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid JWT token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                });
                c.OperationFilter<AuthorizeOperationFilter>();

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
            });

            return services;
        }
    }
}