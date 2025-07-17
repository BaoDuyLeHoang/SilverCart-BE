using SilverCart.Domain.Entities.Orders;

namespace SilverCart.Application.Repositories;

public interface IOrderDetailsRepository : IGenericRepository<OrderDetails>
{
    //Task<IEnumerable<OrderDetails>> GetByOrderIdAsync(Guid orderId);
    //Task<IEnumerable<OrderDetails>> GetByProductItemIdAsync(Guid productItemId);
    //Task<OrderDetails?> GetByIdWithProductAsync(Guid id);
}