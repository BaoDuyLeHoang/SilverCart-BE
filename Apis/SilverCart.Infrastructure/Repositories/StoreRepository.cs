using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SilverCart.Domain.Entities.Stores;

namespace Infrastructures.Repositories
{
    public class StoreRepository : GenericRepository<Store>, IStoreRepository
    {

        //public Task<Store?> GetActiveStoreAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Store?> GetByNameAsync(string name)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> IsStoreActiveAsync(Guid storeId)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task AddStoreProductItemsAsync(List<StoreProductItem> storeProductItems)
        //{
        //    if (storeProductItems == null || !storeProductItems.Any())
        //        return;

        //    await _context.Set<StoreProductItem>().AddRangeAsync(storeProductItems);
        //}
        public StoreRepository(AppDbContext context) : base(context)
        {
        }
    }
}
