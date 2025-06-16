
using System.Security.Cryptography;

namespace SilverCart.Application.Utils
{
    public static class StringUtils
    {
        public static string Hash(this string input)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            var hash = BCrypt.Net.BCrypt.HashPassword(input, salt);
            return $"{hash}:{salt}";
        }

        public static bool VerifyPassword(this string hash, string input)
        {
            var parts = hash.Split(':');
            if (parts.Length != 2)
                throw new ArgumentException("Invalid hash format");

            var hashedPassword = parts[0];
            var salt = parts[1];

            return BCrypt.Net.BCrypt.Verify(input.Hash(), hashedPassword);
        }
        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string GenerateVerifyToken()
        {
            var randomBytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
        public static string GenerateOTPCode()
        {
            Random random = new Random();
            string token = random.Next(100000, 999999).ToString();
            return token;
        }
    }
}