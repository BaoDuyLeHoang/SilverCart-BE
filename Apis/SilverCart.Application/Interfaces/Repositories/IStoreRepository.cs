using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities.Stores;

namespace Infrastructures.Interfaces.Repositories
{
    public interface IStoreRepository : IGenericRepository<Store>
    {
        Task<Store?> GetCurrentStoreAsync();
    }
}
