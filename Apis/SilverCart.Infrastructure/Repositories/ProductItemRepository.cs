using Infrastructures.Commons.Exceptions;
using Infrastructures.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Product> GetProductByProductItemID(Guid productItemId)
        {
            var productItem = await _context.ProductItems.Where(x => x.Id == productItemId).Include(x => x.Variant).ThenInclude(x => x.Product).FirstOrDefaultAsync();
            return productItem.Variant.Product;
        }
    }
}
