using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Interfaces.Repositories
{
    public interface IProductPromotionRepository
    {
        public Task<List<ProductPromotion>> GetByProductIdAsync(Guid productId);
        public Task<List<ProductPromotion>> GetByPromotionIdAsync(Guid promotionId);

    }
}
