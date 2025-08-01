//using Infrastructures.Commons.Exceptions;
//using Infrastructures.Features.Stores.Commands.Create.CreateStore;
//using Infrastructures.Interfaces.System;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using SilverCart.Domain.Enums;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderItemsStatusToShip
//{
//    public sealed record ChangeOrderItemsStatusToShipCommand(Guid OrderId, Guid OrderDetailId, int ServiceTypeId, int PaymentTypeId, RequireNoteEnums RequireNote) : IRequest<ChangeOrderItemsStatusToShipResponse>;
//    public record ChangeOrderItemsStatusToShipResponse(Guid OrderId, Guid StoreProductItemOrderId, string GhnOrderCode);
//    public class ChangeOrderItemsStatusToShipHandler(IUnitOfWork unitOfWork, IGhnService ghnService) : IRequestHandler<ChangeOrderItemsStatusToShipCommand, ChangeOrderItemsStatusToShipResponse>
//    {
//        private readonly IUnitOfWork _unitOfWork = unitOfWork;
//        private readonly IGhnService _ghnService = ghnService;
//        public async Task<ChangeOrderItemsStatusToShipResponse> Handle(ChangeOrderItemsStatusToShipCommand request, CancellationToken cancellationToken)
//        {
//            var orders = await _unitOfWork.OrderRepository.GetAllAsync(
//                predicate: x => x.Id == request.OrderId,
//                include: x => x.Include(x => x.StoreOrders)
//                                .ThenInclude(x => x.StoreProductItemsOrders)
//                                .ThenInclude(x => x.StoreProductItem)
//                                .ThenInclude(x => x.ProductItem)
//                                .ThenInclude(x => x.Variant)
//                                .ThenInclude(x => x.Product)
//                                .Include(x => x.Customer)
//                                    .ThenInclude(x => x.Addresses)
//                                .Include(x => x.StoreOrders).ThenInclude(x => x.Store).ThenInclude(x => x.StoreAddress)
//                                );
//            var order = await orders.FirstOrDefaultAsync();
//            if (order == null)
//            {
//                throw new AppExceptions("Order not found");
//            }
//            var storeOrder = order.StoreOrders.FirstOrDefault(x => x.Id == request.StoreOrderId);
//            if (storeOrder == null)
//            {
//                throw new AppExceptions("Store order not found");
//            }
//            var storeProductItemOrder = storeOrder.StoreProductItemsOrders.FirstOrDefault(x => x.Id == request.StoreProductItemOrderId);
//            if (storeProductItemOrder == null)
//            {
//                throw new AppExceptions("Store product item order not found");
//            }
//            //if (storeProductItemOrder.Status != StoreProductItemsOrderStatus.Processing)
//            //{
//            //    throw new AppExceptions("Store product item order is not processing");
//            //}
//            var store = await _unitOfWork.StoreRepository.GetByIdAsync(storeOrder.StoreId);
//            if (store == null)
//            {
//                throw new AppExceptions("Store not found");
//            }
//            var storeIdGhn = store.GhnShopId;
//            if (storeIdGhn == null)
//            {
//                throw new AppExceptions("Store ghn id not found");
//            }
//            var user = await _unitOfWork.CustomerUserRepository.GetByIdAsync(order.Customer.Id);
//            if (user == null)
//            {
//                throw new AppExceptions("User not found");
//            }
//            storeProductItemOrder.Status = StoreProductItemsOrderStatus.Shipping;
//            _unitOfWork.StoreProductItemOrderRepository.Update(storeProductItemOrder);
//            if (storeOrder.StoreProductItemsOrders.All(x => x.Status == StoreProductItemsOrderStatus.Shipping || x.Status == StoreProductItemsOrderStatus.Cancelled))
//            {
//                storeOrder.Status = StoreOrderStatus.Shipping;
//                _unitOfWork.StoreOrderRepository.Update(storeOrder);
//            }
//            await _unitOfWork.SaveChangeAsync();
//            var ghnOrder = await _ghnService.CreateOrderShippingAsync(new CreateOrderShippingGhnRequest
//            {
//                ShopId = storeIdGhn.Value,
//                ToName = user.FullName,
//                FromName = store.Name,
//                FromPhone = store.Phone,
//                FromAddress = store.StoreAddress.StreetAddress,
//                FromWardName = store.StoreAddress.WardName,
//                FromDistrictName = store.StoreAddress.DistrictName,
//                FromProvinceName = store.StoreAddress.ProvinceName,
//                ToPhone = user.PhoneNumber,
//                ToAddress = user.Addresses.FirstOrDefault()?.StreetAddress,
//                ToWardCode = user.Addresses.FirstOrDefault()?.WardCode,
//                ToDistrictId = user.Addresses.FirstOrDefault().DistrictId,
//                CodAmount = 0,
//                Content = "Đơn hàng từ " + store.Name,
//                Weight = storeProductItemOrder.StoreProductItem.ProductItem.Weight,
//                Length = 0,
//                Width = 0,
//                Height = 0,
//                ServiceTypeId = request.ServiceTypeId,
//                PaymentTypeId = request.PaymentTypeId,
//                RequireNote = request.RequireNote.ToString(),
//                OrderItems = new List<OrderItemsToDelivery>
//                {
//                    new OrderItemsToDelivery
//                    {
//                        Name = storeProductItemOrder.StoreProductItem.ProductItem.Variant.Product.Name,
//                        Quantity = storeProductItemOrder.Quantity,
//                        Weight = storeProductItemOrder.StoreProductItem.ProductItem.Weight,
//                    }
//                }
//            });
//            return new ChangeOrderItemsStatusToShipResponse(order.Id, storeProductItemOrder.Id, ghnOrder);
//        }
//    }
//}
