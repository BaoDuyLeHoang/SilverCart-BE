using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;

namespace SilverCart.Application.Repositories;

public interface IOrderRepository : IGenericRepository<Order>
{
    //Task<IEnumerable<Order>> GetByCustomerIdAsync(Guid customerId);
    //Task<IEnumerable<Order>> GetByStatusAsync(OrderStatusEnums status);
    //Task<Order?> GetByIdWithDetailsAsync(Guid id);
    //Task<IEnumerable<Order>> GetCustomerOrdersAsync(Guid customerId, OrderStatusEnums? status = null);
}