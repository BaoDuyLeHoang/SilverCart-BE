using System.Diagnostics.Eventing.Reader;
using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures;

public interface IGuardianUserRepository : IGenericRepository<GuardianUser>
{
    Task<bool> IsUserInMyFamilyAsync(Guid id, Guid currentUserId);
}
