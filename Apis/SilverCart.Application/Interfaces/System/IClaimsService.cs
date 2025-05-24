using System.Globalization;

namespace SilverCart.Application.Interfaces
{
    public interface IClaimsService
    {
        public Guid CurrentUserId { get; }
        public string CurrentRole { get; }
        public CultureInfo GetUserCultureInfo();
    }
}
