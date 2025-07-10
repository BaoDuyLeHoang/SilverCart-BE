using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities;

namespace Infrastructures.Interfaces.Repositories
{
    public interface IProductVariantRepository : IGenericRepository<ProductVariant>
    {
        //Task<IEnumerable<ProductVariant>> GetByProductIdAsync(Guid productId);
        //Task<ProductVariant?> GetByIdWithItemsAsync(Guid id);
    }
}