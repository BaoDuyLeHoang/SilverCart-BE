using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Interfaces.Repositories
{
    public interface IStoreAddressRepository : IGenericRepository<StoreAddress>
    {
    }
}
