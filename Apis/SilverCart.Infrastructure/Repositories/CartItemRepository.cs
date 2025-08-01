using Infrastructures.Interfaces.Repositories;
using SilverCart.Application.Interfaces.Repositories;
using SilverCart.Domain.Entities.Carts;

namespace Infrastructures.Repositories;

public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
{
    public CartItemRepository(AppDbContext context) : base(context)
    {
    }
}