using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
