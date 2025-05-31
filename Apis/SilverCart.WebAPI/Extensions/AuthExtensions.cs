using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebAPI.Extensions
{
    public static class AuthExtensions
    {
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var key = configuration["JwtSettings:Key"];
            var issuer = configuration["JwtSettings:Issuer"];
            var audience = configuration["JwtSettings:Audience"];

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    };
                });

            services.AddAuthorization();
        }
    }
}
