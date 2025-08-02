using SilverCart.Domain.Entities;
using Infrastructures.Interfaces.Entities;
using SilverCart.Application.Repositories;

namespace Infrastructures.Interfaces.Repositories
{
    public interface IProductImageRepository : IGenericRepository<ProductImage>
    {
    }
}