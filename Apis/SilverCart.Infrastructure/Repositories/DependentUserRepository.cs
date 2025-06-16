using Infrastructures.Repositories;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures;

public class DependentUserRepository : GenericRepository<DependentUser>, IDependentUserRepository
{
    public DependentUserRepository(AppDbContext context) : base(context)
    {
    }
}
