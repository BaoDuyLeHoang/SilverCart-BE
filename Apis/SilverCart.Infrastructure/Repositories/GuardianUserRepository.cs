using Infrastructures.Repositories;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures;

public class GuardianUserRepository : GenericRepository<GuardianUser>, IGuardianUserRepository
{
    public GuardianUserRepository(AppDbContext context) : base(context)
    {
    }
}
