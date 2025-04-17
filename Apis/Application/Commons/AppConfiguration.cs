// Application/Commons/AppConfiguration.cs
namespace Application.Commons
{
    public class AppConfiguration
    {
        public string DatabaseConnection { get; set; }
        public string JWTSecretKey { get; set; }
        public SuperAdminConfig SuperAdmin { get; set; }
        public string ApplicationUrl { get; set; }
        public EmailSettings EmailSettings { get; set; }
    }
    
    public class SuperAdminConfig
    {
        public string Username { get; set; }
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