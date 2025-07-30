using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SilverCart.Domain.Entities.Stores;
using SilverCart.Infrastructure.Commons;

namespace Infrastructures.Repositories
{
    public class StoreRepository : GenericRepository<Store>, IStoreRepository
    {
        private readonly AppConfiguration _configuration;

        public StoreRepository(AppConfiguration configuration, AppDbContext context) : base(context)
        {
            _configuration = configuration;
        }

        public async Task<Store?> GetCurrentStoreAsync()
        {
            return await GetByIdAsync(_configuration.StoreSettings.Id);
        }
    }
}
