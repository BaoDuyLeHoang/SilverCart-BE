using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities.Stores;

namespace Infrastructures.Repositories
{
    public class StoreAddressRepository : GenericRepository<StoreAddress>, IStoreAddressRepository
    {
        public StoreAddressRepository(AppDbContext context) : base(context)
        {
        }
    }
}
