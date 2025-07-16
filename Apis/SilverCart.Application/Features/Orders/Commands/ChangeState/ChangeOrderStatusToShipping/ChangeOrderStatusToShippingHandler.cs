using Infrastructures.Commons.Exceptions;
using Infrastructures.Features.Stores.Commands.Create.CreateStore;
using Infrastructures.Interfaces.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SilverCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderStatusToShipping
{
    public sealed record ChangeOrderStatusToShippingCommand(Guid OrderId, int ServiceTypeId, int PaymentTypeId, RequireNoteEnums RequireNote) : IRequest<ChangeOrderStatusToShippingResponse>;
    public record ChangeOrderStatusToShippingResponse(Guid OrderId, string GhnOrderCode);
    public class ChangeOrderStatusToShippingHandler(IUnitOfWork unitOfWork, IGhnService ghnService) : IRequestHandler<ChangeOrderStatusToShippingCommand, ChangeOrderStatusToShippingResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IGhnService _ghnService = ghnService;
        public async Task<ChangeOrderStatusToShippingResponse> Handle(ChangeOrderStatusToShippingCommand request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.OrderRepository.GetAllAsync(
                predicate: x => x.Id == request.OrderId,
                include: src => src.Include(x => x.OrderDetails)
                                   .ThenInclude(x => x.ProductItem)
                );
            if (orders == null || !orders.Any())
                throw new AppExceptions($"Order with ID {request.OrderId} not found");

            var order = orders.FirstOrDefault();
            if (order.OrderStatus != OrderStatusEnum.StoreConfirmed)
                throw new AppExceptions("Order is not in a state that can be changed to shipping");

            var store = await _unitOfWork.StoreRepository.GetByIdAsync(Guid.Parse("c4f31cea-14f3-45cd-98ad-39d68e78e0e7"));
            if (store == null)
                throw new AppExceptions("Store not found");

            var ghnShopId = store.GhnShopId;
            if (ghnShopId == null || ghnShopId == 0)
                throw new AppExceptions("Store does not have a valid GHN shop ID");

            var users = await _unitOfWork.UserRepository.GetAllAsync(
                predicate: x => x.Id == order.DependentUserID,
                include: src => src.Include(x => x.Addresses)
                );
            var user = users.FirstOrDefault();

            if (user == null)
                throw new AppExceptions("User not found");

            var totalWeightOfOrder = order.OrderDetails.Sum(x => x.Quantity * x.ProductItem.Weight);
            var totalLengthOfOrder = order.OrderDetails.Sum(x => x.Quantity * x.ProductItem.Length);
            var totalWidthOfOrder = order.OrderDetails.Sum(x => x.Quantity * x.ProductItem.Width);
            var totalHeightOfOrder = order.OrderDetails.Sum(x => x.Quantity * x.ProductItem.Height);

            var ghnOrder = await _ghnService.CreateOrderShippingAsync(new CreateOrderShippingGhnRequest
            {
                ShopId = ghnShopId.Value,
                ToName = user.FullName,
                FromName = store.Name,
                FromPhone = store.Phone,
                FromAddress = store.StoreAddress.Address,
                FromWardName = store.StoreAddress.WardName,
                FromDistrictName = store.StoreAddress.DistrictName,
                FromProvinceName = store.StoreAddress.ProvinceName,
                ToPhone = user.PhoneNumber,
                ToAddress = user.Addresses.FirstOrDefault()?.StreetAddress,
                ToWardCode = user.Addresses.FirstOrDefault()?.WardCode,
                ToDistrictId = user.Addresses.FirstOrDefault().DistrictId,
                CodAmount = 0,
                Content = "Đơn hàng từ " + store.Name,
                Weight = totalWeightOfOrder,
                Length = totalLengthOfOrder,
                Width = totalWidthOfOrder,
                Height = totalHeightOfOrder,
                ServiceTypeId = request.ServiceTypeId,
                PaymentTypeId = request.PaymentTypeId,
                RequireNote = request.RequireNote.ToString(),
                OrderItems = order.OrderDetails.Select(orderDetail => new OrderItemsToDelivery
                {
                    Name = orderDetail.ProductItem.Variant.Product.Name,
                    Quantity = orderDetail.Quantity,
                    Weight = orderDetail.ProductItem.Weight,
                }).ToList()
            });

            if (ghnOrder.IsNullOrEmpty())
                throw new AppExceptions("Failed to create GHN order");

            order.OrderStatus = OrderStatusEnum.Shipping;
            order.OrderGhnCode = ghnOrder;

            foreach (var orderDetail in order.OrderDetails)
            {
                if (orderDetail.OrderItemStatus == OrderItemStatusEnums.Cancelled)
                {
                    orderDetail.OrderItemStatus = OrderItemStatusEnums.Cancelled;
                }
                else
                {
                    orderDetail.OrderItemStatus = OrderItemStatusEnums.Shipping;
                    _unitOfWork.OrderDetailsRepository.Update(orderDetail);
                }
            }
            _unitOfWork.OrderRepository.Update(order);
            await _unitOfWork.SaveChangeAsync();

            return new ChangeOrderStatusToShippingResponse(order.Id, ghnOrder);
        }
    }
}
