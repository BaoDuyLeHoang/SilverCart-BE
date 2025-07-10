// SilverCart.ApplicationCommons/AppConfiguration.cs

namespace SilverCart.Infrastructure.Commons
{
    public class AppConfiguration
    {
        public string DatabaseConnection { get; set; }
        public string RedisConnection { get; set; }
        public string JWTSecretKey { get; set; }
        public SuperAdminConfig SuperAdmin { get; set; }
        public string ApplicationUrl { get; set; }
        public EmailSettings EmailSettings { get; set; }
        public bool IsDevelopment { get; set; }
        public VNPAYSettings Vnpay { get; set; }
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
}