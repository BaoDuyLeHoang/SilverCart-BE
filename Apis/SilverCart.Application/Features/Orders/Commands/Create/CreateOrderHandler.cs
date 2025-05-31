using System;
using AutoMapper;
using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;

namespace Infrastructures.Features.Orders.Commands.Create;

public sealed record CreateOrderCommand(List<CreateOrderItem> OrderItems) : IRequest<Guid>;
public record CreateOrderItem(Guid StoreProductId, int Quantity);
public class CreateOrderHandler(IUnitOfWork unitOfWork, IClaimsService claimsService, IMapper mapper) : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IClaimsService _claimsService = claimsService;
    private readonly IMapper _mapper = mapper;
    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimsService.CurrentUserId;
        if (currentUserId == Guid.Empty)
            throw new UnauthorizedAccessException("User not authenticated.");

        var customerUser = await _unitOfWork.CustomerUserRepository.GetByIdAsync(currentUserId);
        if (customerUser == null)
            throw new AppExceptions("User not found.");

        var storeProductItems = await _unitOfWork.StoreProductItemRepository.GetAllAsync(predicate: _ => true, include: x => x.Include(x => x.ProductItem));
        var storeProductItemsIds = storeProductItems.Select(item => item.Id).ToList();
        var productItemsPrices = storeProductItems.ToDictionary(item => item.Id, item => item.ProductItem.DiscountedPrice);
        var orderItems = request.OrderItems.Where(item => storeProductItemsIds.Contains(item.StoreProductId)).ToList();
        if (orderItems.Count != request.OrderItems.Count)
            throw new AppExceptions("Invalid store product id.");

        var orderItemsToCheck = orderItems.Select(item => new OrderItem
        {
            StoreProductItemId = item.StoreProductId,
            Quantity = item.Quantity,
            Price = (double)productItemsPrices[item.StoreProductId],
        }).ToList();

        var checkStock = await _unitOfWork.StoreProductItemRepository.CheckStock(orderItemsToCheck);
        if (!checkStock)
            throw new AppExceptions("Stock not enough.");

        var order = new Order
        {
            CustomerId = currentUserId,
            TotalPrice = (double)orderItems.Sum(item => productItemsPrices[item.StoreProductId] * item.Quantity),
            OrderItems = orderItems.Select(item => new OrderItem
            {
                StoreProductItemId = item.StoreProductId,
                Quantity = item.Quantity,
                Price = (double)productItemsPrices[item.StoreProductId],
            }).ToList(),
        };

        var reduceStock = await _unitOfWork.StoreProductItemRepository.ReduceStock(orderItemsToCheck);
        if (!reduceStock)
            throw new AppExceptions("Reduce stock failed.");

        await _unitOfWork.OrderRepository.AddAsync(order);
        await _unitOfWork.SaveChangeAsync();
        return order.Id;
    }
}
