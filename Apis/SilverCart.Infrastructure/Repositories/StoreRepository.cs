using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class StoreRepository : GenericRepository<Store>, IStoreRepository
    {
        private readonly AppDbContext _context;

        public StoreRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddStoreProductItemsAsync(List<StoreProductItem> storeProductItems)
        {
            if (storeProductItems == null || !storeProductItems.Any())
                return;

            await _context.Set<StoreProductItem>().AddRangeAsync(storeProductItems);
        }
    }
}
