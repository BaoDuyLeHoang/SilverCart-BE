using SilverCart.Domain.Entities;

namespace Infrastructures.Repositories
{
    public class UserPromotionRepository : GenericRepository<UserPromotion>, IUserPromotionRepository
    {
        public UserPromotionRepository(AppDbContext context) : base(context)
        {
        }
    }
}

