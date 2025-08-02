using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;

namespace Infrastructures.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Order?> GetDetailedOrderAsync(Guid id)
    {
        return await _dbSet.Include(x => x.OrderDetails).ThenInclude(x => x.ProductItem).ThenInclude(x => x.Product).FirstOrDefaultAsync(x => x.Id == id);
    }


}