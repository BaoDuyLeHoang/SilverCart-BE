using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repositories
{
    public class ProductVariantsRepository : GenericRepository<ProductVariant>, IProductVariantRepository
    {
        public ProductVariantsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
