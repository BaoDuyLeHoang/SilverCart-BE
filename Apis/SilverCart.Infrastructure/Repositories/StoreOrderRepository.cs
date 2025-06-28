using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities;

namespace Infrastructures.Repositories
{
    public class StoreOrderRepository : GenericRepository<StoreOrder>, IStoreOrderRepository
    {
        public StoreOrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}