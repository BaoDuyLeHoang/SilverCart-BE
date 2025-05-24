using System;
using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities;

namespace Infrastructures.Repositories;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(AppDbContext context) : base(context)
    {
    }
}
