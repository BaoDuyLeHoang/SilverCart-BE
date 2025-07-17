using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities.Products;

namespace Infrastructures.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
