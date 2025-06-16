using System.Linq.Expressions;
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

    //public async Task<Order?> GetByIdAsync(Guid id, params Expression<Func<Order, object>>[] includes)
    //{
    //    return new Order()
    //    {
    //        // create a new order object
    //        Id = id,
    //        Address = "123 Main St",
    //        UserRank = RankEnum.Gold,
    //        TotalPrice = 10000.0,
    //        DeadlineDate = DateTime.UtcNow.AddDays(7),
    //        EstimatedArrivedDate = DateTime.UtcNow.AddDays(5),
    //        ArrivedDate = DateTime.UtcNow.AddDays(3),
    //        UserPromotionId = Guid.NewGuid(),
    //        CreationDate = DateTime.Today
    //    };
    //}
}