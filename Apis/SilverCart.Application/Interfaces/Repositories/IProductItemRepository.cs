using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities.Products;

namespace Infrastructures.Interfaces.Repositories
{
    public interface IProductItemRepository : IGenericRepository<ProductItem>
    {
        //Task<IEnumerable<ProductItem>> GetByVariantIdAsync(Guid variantId);
        //Task<IEnumerable<ProductItem>> GetByStoreIdAsync(Guid storeId);
        //Task<ProductItem?> GetBySkuAsync(string sku);
        //Task<IEnumerable<ProductItem>> GetActiveItemsAsync();
        //Task<bool> AddProductItemsToStore(List<AddProductItemsToStore> productIds);
    }
}
