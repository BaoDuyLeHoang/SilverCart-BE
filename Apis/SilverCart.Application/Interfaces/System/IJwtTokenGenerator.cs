using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Interfaces.System
{
    public interface IJwtTokenGenerator
    {
        string GenerateJwtToken(BaseUser user, string userRole);
        string GenerateRefreshToken();
        public string GenerateQrLoginToken(Guid dependentUserId, int expiresInMinutes = 2);
    }
}
