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
    public sealed record ChangeOrderItemsToStoreConfirmCommand(Guid OrderId, Guid OrderDetailId) : IRequest<bool>;
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
                include: x => x.Include(x => x.OrderDetails)
                                .ThenInclude(x => x.ProductItem));
            var order = await orders.FirstOrDefaultAsync();
            var customerId = order?.DependentUserID;

            var orderDetails = order.OrderDetails.FirstOrDefault(x => x.Id == request.OrderDetailId);
            if (orderDetails == null)
            {
                throw new AppExceptions("Order detail not found");
            }
            if (orderDetails.OrderItemStatus != OrderItemStatusEnums.ConfirmedByGuardian)
            {
                throw new AppExceptions("Order item is not confirmed by guardian");
            }
            orderDetails.OrderItemStatus = OrderItemStatusEnums.ConfirmedByStore;
            _unitOfWork.OrderDetailsRepository.Update(orderDetails);

            if (order.OrderDetails.All(x => x.OrderItemStatus == OrderItemStatusEnums.ConfirmedByStore || x.OrderItemStatus == OrderItemStatusEnums.Cancelled))
            {
                order.OrderStatus = OrderStatusEnum.StoreConfirmed;
                _unitOfWork.OrderRepository.Update(order);
            }
            await _unitOfWork.SaveChangeAsync();
            return true;
        }
    }
}