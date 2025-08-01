using Infrastructures.Repositories;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures;

public class GuardianUserRepository : GenericRepository<GuardianUser>, IGuardianUserRepository
{
    public GuardianUserRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<bool> IsUserInMyFamilyAsync(Guid id, Guid currentUserId)
    {
        var guardian = await GetByIdAsync(id, includes: u => u.Dependents);
        if (guardian == null)
            return false;
        return guardian.Dependents.Any(d => d.Id == currentUserId);
    }
}
