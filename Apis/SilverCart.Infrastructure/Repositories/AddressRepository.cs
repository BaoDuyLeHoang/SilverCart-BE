using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Stores;

namespace Infrastructures.Repositories
{
    public class AddressRepository : GenericRepository<SavedAddress>, IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<StoreAddress?> GetStoreAddressByStoreIdAsync(Guid storeId)
        {
            return await _context.StoreAddresses.FirstOrDefaultAsync(a => a.Id == storeId);
        }
    }
}

