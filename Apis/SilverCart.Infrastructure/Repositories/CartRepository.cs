using Infrastructures.Interfaces.Repositories;
using SilverCart.Application.Interfaces.Repositories;
using SilverCart.Domain.Entities.Carts;

namespace Infrastructures.Repositories;

public class CartRepository : GenericRepository<Cart>, ICartRepository
{
    public CartRepository(AppDbContext context) : base(context)
    {
    }
}