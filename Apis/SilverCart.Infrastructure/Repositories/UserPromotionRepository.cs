using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Promotions;

namespace Infrastructures.Repositories
{
    public class UserPromotionRepository : GenericRepository<UserPromotion>, IUserPromotionRepository
    {
        public UserPromotionRepository(AppDbContext context) : base(context)
        {
        }
    }
}

