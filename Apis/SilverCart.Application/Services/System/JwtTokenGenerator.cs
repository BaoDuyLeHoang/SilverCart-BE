using Infrastructures.Interfaces.System;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructures.Services.Entities
{
    public class JwtTokenGenerator(IConfiguration configuration, ICurrentTime currentTime) : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly ICurrentTime _currentTime = currentTime;

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public string GenerateJwtToken(BaseUser user, string userRole)
        {
            var key = _configuration["JwtSettings:Key"];
            var issuer = _configuration["JwtSettings:Issuer"];
            var audience = _configuration["JwtSettings:Audience"];
            var expires = int.Parse(_configuration["JwtSettings:ExpiresInMinutes"] ?? "30");

            var claims = new List<Claim>
            {
                new Claim("UserId", user.Id.ToString()),
                new (ClaimTypes.Role, userRole),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: _currentTime.GetCurrentTime().AddMinutes(expires),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
