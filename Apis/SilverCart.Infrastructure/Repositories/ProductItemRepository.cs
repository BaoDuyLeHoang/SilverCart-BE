using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class ProductItemRepository : GenericRepository<ProductItem>, IProductItemRepository
    {
        public ProductItemRepository(AppDbContext context) : base(context)
        {
        }
    }
}
