using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities;
using Infrastructures.Repositories;

namespace Infrastructures.Repositories
{
    public class ProductImageRepository : GenericRepository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(AppDbContext context) : base(context)
        {
        }
    }
}