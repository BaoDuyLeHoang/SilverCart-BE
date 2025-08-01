using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures.Repositories
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(AppDbContext context) : base(context)
        {
        }
    }
}