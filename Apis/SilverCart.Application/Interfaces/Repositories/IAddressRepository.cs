using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Stores;

namespace SilverCart.Application.Repositories;

public interface IAddressRepository : IGenericRepository<SavedAddress>
{
    Task<StoreAddress?> GetStoreAddressByStoreIdAsync(Guid storeId);
}