using System;
using AutoMapper;
using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Orders.Commands.Create;

public sealed record CreateOrderCommand(List<CreateStoreOrder> OrderItems) : IRequest<Guid>;
public record CreateStoreOrder(Guid StoreId, List<CreateStoreProductItemsOrder> StoreProductItemsOrders);
public record CreateStoreProductItemsOrder(Guid StoreProductItemId, int Quantity);
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

        var order = new Order
        {
            CustomerId = currentUserId,
            StoreOrders = new List<StoreOrder>()
        };

        foreach (var storeOrder in request.OrderItems)
        {
            var store = await _unitOfWork.StoreRepository.GetByIdAsync(storeOrder.StoreId);
            if (store == null)
                throw new AppExceptions($"Store with ID {storeOrder.StoreId} not found.");
            var storeOrderEntity = new StoreOrder
            {
                StoreId = store.Id,
                TotalPrice = 0,
                ShippingStatus = StoreOrderShippingGhnStatusEnum.ReadyToPick,
                StoreProductItemsOrders = new List<StoreProductItemsOrder>()
            };
            foreach (var item in storeOrder.StoreProductItemsOrders)
            {
                var productItems = await _unitOfWork.StoreProductItemRepository.GetAllAsync
                (
                    predicate: x => x.Id == item.StoreProductItemId && x.StoreId == store.Id,
                    include: x => x.Include(x => x.ProductItem).ThenInclude(x => x.Variant).ThenInclude(x => x.Product)
                );

                var productItem = productItems.FirstOrDefault();
                if (productItem == null)
                    throw new AppExceptions($"Store Product Item with ID {item.StoreProductItemId} not found.");
                if (productItem.Stock < item.Quantity)
                    throw new AppExceptions($"Insufficient quantity for product item {item.StoreProductItemId}.");
                productItem.Stock -= item.Quantity;
                storeOrderEntity.StoreProductItemsOrders.Add(new StoreProductItemsOrder
                {
                    StoreProductItemId = productItem.Id,
                    Price = (double)productItem.ProductItem.DiscountedPrice,
                    Quantity = item.Quantity
                });
                storeOrderEntity.TotalPrice += (double)productItem.ProductItem.DiscountedPrice * item.Quantity;
                _unitOfWork.StoreProductItemRepository.Update(productItem);
            }
            order.StoreOrders.Add(storeOrderEntity);
        }
        order.TotalPrice = order.StoreOrders.Sum(x => x.TotalPrice);

        await _unitOfWork.OrderRepository.AddAsync(order);
        await _unitOfWork.SaveChangeAsync();
        return order.Id;
    }
}
