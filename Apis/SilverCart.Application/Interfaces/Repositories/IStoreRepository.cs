using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Interfaces.Repositories
{
    public interface IStoreRepository : IGenericRepository<Store>
    {
        //Task<Store?> GetActiveStoreAsync();
        //Task<Store?> GetByNameAsync(string name);
        //Task<bool> IsStoreActiveAsync(Guid storeId);
    }
}
