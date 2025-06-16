using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Chat;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderItemsToStoreConfirm
{
    public sealed record ChangeOrderItemsToStoreConfirmCommand(Guid OrderId, Guid StoreOrderId, Guid StoreProductItemOrderId) : IRequest<bool>;
    public class ChangeOrderItemsToStoreConfirmHandler(IUnitOfWork unitOfWork, UserManager<BaseUser> userManager, IClaimsService claimsService) : IRequestHandler<ChangeOrderItemsToStoreConfirmCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly UserManager<BaseUser> _userManager = userManager;
        private readonly IClaimsService _claimsService = claimsService;
        public async Task<bool> Handle(ChangeOrderItemsToStoreConfirmCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _claimsService.CurrentUserId;
            var currentUser = await _userManager.FindByIdAsync(currentUserId.ToString());
            if (currentUser == null) throw new AppExceptions("User not found");
            var isOwnerOfAnyStore = await _unitOfWork.StoreUserRepository.GetAllAsync(x => x.Id == currentUserId);
            if (!isOwnerOfAnyStore.Any())
            {
                throw new AppExceptions("User is not owner of any store");
            }

            var orders = await _unitOfWork.OrderRepository.GetAllAsync(
                predicate: x => x.Id == request.OrderId,
                include: x => x.Include(x => x.StoreOrders)
                                .ThenInclude(x => x.StoreProductItemsOrders)
                                .ThenInclude(x => x.StoreProductItem)
                                .ThenInclude(x => x.ProductItem));
            var order = await orders.FirstOrDefaultAsync();
            var customerId = order?.CustomerId;

            var storeOrder = order.StoreOrders.FirstOrDefault(x => x.Id == request.StoreOrderId);
            if (storeOrder == null)
            {
                throw new AppExceptions("Store order not found");
            }
            var storeProductItemOrder = storeOrder.StoreProductItemsOrders.FirstOrDefault(x => x.Id == request.StoreProductItemOrderId);
            if (storeProductItemOrder == null)
            {
                throw new AppExceptions("Store product item order not found");
            }
            if (storeProductItemOrder.Status != StoreProductItemsOrderStatus.ConfirmedByGuardian)
            {
                throw new AppExceptions("Store product item order is not confirmed by guardian");
            }
            storeProductItemOrder.Status = StoreProductItemsOrderStatus.Processing;
            _unitOfWork.StoreProductItemOrderRepository.Update(storeProductItemOrder);
            if (storeOrder.StoreProductItemsOrders.All(x => x.Status == StoreProductItemsOrderStatus.Processing || x.Status == StoreProductItemsOrderStatus.Cancelled))
            {
                storeOrder.Status = StoreOrderStatus.Confirmed;
                _unitOfWork.StoreOrderRepository.Update(storeOrder);
            }
            await _unitOfWork.SaveChangeAsync();
            return true;
        }
    }
}