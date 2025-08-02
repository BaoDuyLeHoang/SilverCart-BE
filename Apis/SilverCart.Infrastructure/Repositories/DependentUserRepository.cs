using Infrastructures.Repositories;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures;

public class DependentUserRepository : GenericRepository<DependentUser>, IDependentUserRepository
{
    public DependentUserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> IsUserInMyFamilyAsync(Guid currentUserId, Guid id)
    {
        var dependent = await GetByIdAsync(id, includes: u => u.Guardian);
        if (dependent == null)
            return false;
        return dependent.GuardianId == currentUserId;
    }
}