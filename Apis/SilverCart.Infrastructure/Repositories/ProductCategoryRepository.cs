using Infrastructures.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SilverCart.Domain.Entities.Categories;

namespace Infrastructures.Repositories
{
    public class ProductCategoryRepository : GenericMutationRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(AppDbContext context) : base(context)
        {
        }

        public Task<ProductCategory?> GetByProductIdAndCategoryIdAsync(Guid productId, Guid categoryId)
        {
            return _dbSet.FirstOrDefaultAsync(pc => pc.ProductId == productId && pc.CategoryId == categoryId);
        }
    }
}