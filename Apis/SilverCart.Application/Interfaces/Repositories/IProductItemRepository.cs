using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Interfaces.Repositories
{
    public interface IProductItemRepository : IGenericRepository<ProductItem>
    {
        //Task<bool> AddProductItemsToStore(List<AddProductItemsToStore> productIds);
    }
}
