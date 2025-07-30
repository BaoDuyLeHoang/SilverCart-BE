using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures;

public interface IDependentUserRepository : IGenericRepository<DependentUser>
{
    Task<bool> IsUserInMyFamilyAsync(Guid currentUserId, Guid id);
}
