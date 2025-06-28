using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities;

namespace Infrastructures.Repositories
{
    public class StoreProductItemOrderRepository : GenericRepository<StoreProductItemsOrder>, IStoreProductItemOrderRepository
    {
        public StoreProductItemOrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}