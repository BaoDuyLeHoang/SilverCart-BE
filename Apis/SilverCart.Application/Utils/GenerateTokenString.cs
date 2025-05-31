using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using SilverCart.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace SilverCart.Application.Utils
{
    public static class GenerateTokenString
    {
        public static string GenerateJsonWebToken(this BaseUser baseUser, string secretKey, DateTime now)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            Debug.Assert(baseUser.Email != null, "baseUser.Email != null");
            var claims = new[]
            {
<<<<<<< HEAD:Apis/Application/Utils/GenerateTokenString.cs
                new Claim(ClaimTypes.NameIdentifier ,baseUser.Email),
                new Claim(ClaimTypes.Role ,"SuperAdmin"),
=======
                new Claim(ClaimTypes.NameIdentifier, baseUser.Email),
                new Claim(ClaimTypes.Role, "SuperAdmin"),
>>>>>>> main:Apis/SilverCart.Application/Utils/GenerateTokenString.cs
            };
            var token = new JwtSecurityToken(
                claims: claims,
                expires: now.AddHours(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}