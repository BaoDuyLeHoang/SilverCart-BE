using Application.Interfaces;
using System.Security.Claims;

namespace WebAPI.Services
{
    public class ClaimsService : IClaimsService
    {
        public ClaimsService(IHttpContextAccessor httpContextAccessor)
        {
            // todo implementation to get the current userId
            var id = httpContextAccessor.HttpContext?.User?.FindFirstValue("userId");
            GetCurrentUserId = string.IsNullOrEmpty(id) ? Guid.Empty : Guid.Parse(id);
        }

        public Guid GetCurrentUserId { get; }
    }
}