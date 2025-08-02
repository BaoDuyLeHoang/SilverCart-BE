using System.Globalization;
using SilverCart.Domain.Enums;
namespace SilverCart.Application.Interfaces
{
    public interface IClaimsService
    {
        public Guid CurrentUserId { get; }
        public RoleEnum? CurrentRole { get; }
        public CultureInfo GetUserCultureInfo();
    }
}
