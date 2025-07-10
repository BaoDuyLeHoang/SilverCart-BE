using Infrastructures.Services.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Interfaces.System
{
    public interface IStringeeService
    {
        Task<string> RegisterUserAsync(StringeeUserRegistrationRequest request);
        Task<string> GenerateAccessTokenAsync(Guid userId, string role);
    }
}
