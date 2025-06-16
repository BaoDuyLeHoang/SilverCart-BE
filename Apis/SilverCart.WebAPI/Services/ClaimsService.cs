using System.Globalization;
using System.Security.Claims;
using SilverCart.Application.Interfaces;

namespace WebAPI.Services
{
    public class ClaimsService : IClaimsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimsService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            var id = httpContextAccessor.HttpContext?.User?.FindFirstValue("UserId");
            CurrentUserId = string.IsNullOrEmpty(id) ? Guid.Empty : Guid.Parse(id);
            CurrentRole = httpContextAccessor.HttpContext?.User?.FindFirstValue("Role") ?? "";
        }

        public CultureInfo GetUserCultureInfo()
        {
            var request = _httpContextAccessor.HttpContext?.Request;

            var languageHeader = request?.Headers["Accept-Language"].ToString();
            if (string.IsNullOrEmpty(languageHeader)) return CultureInfo.InvariantCulture;

            var cultureCode = languageHeader.Split(',').FirstOrDefault(); // e.g., "en-US,en;q=0.9,vi;q=0.8"
            if (string.IsNullOrEmpty(cultureCode)) return CultureInfo.InvariantCulture;

            try
            {
                return new CultureInfo("vi");
            }
            catch (CultureNotFoundException)
            {
                // fallback
            }

            return CultureInfo.InvariantCulture;
        }

        public Guid CurrentUserId { get; }
        public string CurrentRole { get; }
    }
}