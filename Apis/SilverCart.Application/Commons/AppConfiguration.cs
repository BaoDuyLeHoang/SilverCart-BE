// SilverCart.ApplicationCommons/AppConfiguration.cs

using Confluent.Kafka;

namespace SilverCart.Infrastructure.Commons
{
    public class AppConfiguration
    {
        public string DatabaseConnection { get; set; } = string.Empty;
        public string RedisConnection { get; set; } = string.Empty;
        public string RedisPassword { get; set; } = string.Empty;
        public string JWTSecretKey { get; set; } = string.Empty;
        public SuperAdminConfig SuperAdmin { get; set; } = new SuperAdminConfig();
        public string ApplicationUrl { get; set; } = string.Empty;
        public EmailSettings EmailSettings { get; set; } = null!;
        public bool IsDevelopment { get; set; } = false;
        public VNPAYSettings Vnpay { get; set; } = null!;
    }

    public class VNPAYSettings
    {
        public string TmnCode { get; set; }
        public string HashSecret { get; set; }
        public string BaseUrl { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class SuperAdminConfig
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class EmailSettings
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
    }


    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int ExpiresInMinutes { get; set; } = 30;
    }
}