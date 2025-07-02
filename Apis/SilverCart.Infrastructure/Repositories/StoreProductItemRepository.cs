using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class StoreProductItemRepository : GenericRepository<StoreProductItem>, IStoreProductItemRepository
    {
        public StoreProductItemRepository(AppDbContext context) : base(context)
        {
        }

        // public async Task<bool> CheckStock(List<OrderItem> orderItems)
        // {
        //     var ids = orderItems.Select(x => x.StoreProductItemId).ToList();
        //     var storeProductItems = await GetAllAsync(sp => ids.Contains(sp.Id));

        //     foreach (var orderItem in orderItems)
        //     {
        //         var storeProductItem = storeProductItems.FirstOrDefault(sp => sp.Id == orderItem.StoreProductItemId);
        //         if (storeProductItem == null || storeProductItem.Stock < orderItem.Quantity)
        //             return false;
        //     }
        //     return true;
        // }

        // public async Task<bool> ReduceStock(List<OrderItem> orderItems)
        // {
        //     var ids = orderItems.Select(x => x.StoreProductItemId).ToList();
        //     var storeProductItems = await GetAllAsync(sp => ids.Contains(sp.Id));

        //     foreach (var orderItem in orderItems)
        //     {
        //         var storeProductItem = storeProductItems.FirstOrDefault(sp => sp.Id == orderItem.StoreProductItemId);
        //         if (storeProductItem == null || storeProductItem.Stock < orderItem.Quantity)
        //             return false;
        //         storeProductItem.Stock -= orderItem.Quantity;
        //         Update(storeProductItem);
        //     }
        //     return true;
        // }
    }
}
