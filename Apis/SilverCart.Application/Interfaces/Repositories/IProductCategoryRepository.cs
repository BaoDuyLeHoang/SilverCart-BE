using SilverCart.Application.Repositories;
using SilverCart.Domain.Common.Interfaces;
using SilverCart.Domain.Entities.Categories;
using SilverCart.Domain.Entities.Products;

namespace Infrastructures.Interfaces.Repositories
{
    public interface IProductCategoryRepository : IGenericMutationRepository<ProductCategory>
    {
        Task<ProductCategory?> GetByProductIdAndCategoryIdAsync(Guid productId, Guid categoryId);
    }
}
