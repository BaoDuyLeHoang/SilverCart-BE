using Infrastructures.Interfaces.Entities;
using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures.Repositories
{
    public class AdministratorUserRepository : GenericRepository<AdministratorUser>, IAdministratorUserRepository
    {
        public AdministratorUserRepository(AppDbContext context) : base(context)
        {
        }

    }
}
