using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Services.System;
using SilverCart.Domain.Enums;
using SilverCart.Infrastructure.Commons;
using Microsoft.Extensions.Logging;

namespace Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderStatusToShipping;

public sealed record ChangeOrderStatusToShippingCommand(
    Guid OrderId,
    Guid ToAddressId,  // Add delivery address
    GhnRequireNoteEnum RequireNote
) : IRequest<ChangeOrderStatusToShippingResponse>;

public record ChangeOrderStatusToShippingResponse(
    Guid OrderId,
    string OrderCode,
    ShippingStatusEnum ShippingStatus
);

public class ChangeOrderStatusToShippingHandler : IRequestHandler<ChangeOrderStatusToShippingCommand, ChangeOrderStatusToShippingResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGhnService _ghnService;
    private readonly AppConfiguration _configuration;
    private readonly ILogger<ChangeOrderStatusToShippingHandler> _logger;

    public ChangeOrderStatusToShippingHandler(
        IUnitOfWork unitOfWork,
        IGhnService ghnService,
        AppConfiguration configuration,
        ILogger<ChangeOrderStatusToShippingHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _ghnService = ghnService;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<ChangeOrderStatusToShippingResponse> Handle(ChangeOrderStatusToShippingCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            _logger.LogInformation("Bắt đầu xử lý chuyển trạng thái đơn hàng {OrderId} sang vận chuyển", request.OrderId);

            // 1. Get order with all required data
            var order = await _unitOfWork.OrderRepository.GetDetailedOrderAsync(request.OrderId);
            AppExceptions.ThrowIfNotFound(order, $"Đơn hàng không tồn tại với ID {request.OrderId}");

            if (order.OrderStatus != OrderStatusEnum.StoreConfirmed)
            {
                _logger.LogWarning("Đơn hàng {OrderId} không ở trạng thái có thể chuyển sang vận chuyển. Trạng thái hiện tại: {CurrentStatus}",
                    request.OrderId, order.OrderStatus);
                throw new AppExceptions("Đơn hàng không ở trạng thái có thể chuyển sang trạng thái vận chuyển");
            }

            // 2. Get store data
            var store = await _unitOfWork.StoreRepository.GetByIdAsync(_configuration.StoreSettings.Id, x => x.StoreAddress);
            AppExceptions.ThrowIfNotFound(store, "Cửa hàng không tồn tại");

            if (!store.GhnShopId.HasValue || store.GhnShopId.Value == 0)
            {
                _logger.LogError("Cửa hàng {StoreId} không có ID GHN hợp lệ", store.Id);
                throw new AppExceptions("Cửa hàng không có ID GHN hợp lệ");
            }

            // 3. Get addresses
            var toAddress = await _unitOfWork.AddressRepository.GetByIdAsync(request.ToAddressId);
            AppExceptions.ThrowIfNotFound(toAddress, $"Địa chỉ giao hàng không tồn tại với ID {request.ToAddressId}");

            // 4. Get user info
            var user = await _unitOfWork.UserRepository.GetByIdAsync(order.CustomerUserId.Value);
            AppExceptions.ThrowIfNotFound(user, "Không tìm thấy thông tin người đặt hàng");

            // 5. Calculate dimensions
            int weight = order.OrderDetails.Sum(od => od.Weight * od.Quantity);
            int length = order.OrderDetails.Sum(od => od.Length * od.Quantity);
            int width = order.OrderDetails.Sum(od => od.Width * od.Quantity);
            int height = order.OrderDetails.Sum(od => od.Height * od.Quantity);

            _logger.LogInformation("Tạo đơn hàng GHN cho đơn hàng {OrderId}. Kích thước: {Length}x{Width}x{Height}, Cân nặng: {Weight}g",
                request.OrderId, length, width, height, weight);

            // 6. Create GHN order using built-in function
            var ghnRequest = GhnCreateOrderRequest.ToCreateGHNOrder(user: user, orderDetails: order.OrderDetails.ToList(),
                                                                    store: store, fromAddress: store.StoreAddress,
                                                                    toSavedAddress: toAddress, weight: weight, length: length,
                                                                    width: width, height: height,
                                                                    paymentTypeId: order.PaymentStatus.PaymentMethod,
                                                                    note: order.OrderNote ?? string.Empty);

            // Add required note from request
            ghnRequest.RequiredNote = request.RequireNote;

            // Set COD amount if payment method is Cash
            if (order.PaymentStatus.PaymentMethod == PaymentMethodEnum.Cash)
            {
                ghnRequest.CodAmount = (int)order.FinalPrice;
            }

            // Set insurance value
            ghnRequest.InsuranceValue = (int)order.FinalPrice;

            var ghnResponse = await _ghnService.CreateShippingOrder(ghnRequest);
            if (ghnResponse?.OrderCode == null)
            {
                _logger.LogError("Tạo đơn hàng GHN thất bại cho đơn hàng {OrderId}", request.OrderId);
                throw new AppExceptions("Tạo đơn hàng GHN thất bại");
            }

            _logger.LogInformation("Đã tạo đơn hàng GHN thành công cho đơn hàng {OrderId}. Mã GHN: {GhnOrderCode}",
                request.OrderId, ghnResponse.OrderCode);

            // 7. Update order status
            order.OrderStatus = OrderStatusEnum.Shipping;
            order.OrderCode = ghnResponse.OrderCode;
            order.ShippingStatus.Status = ShippingStatusEnum.Shipping;

            // 8. Update order details status
            foreach (var orderDetail in order.OrderDetails)
            {
                if (orderDetail.OrderItemStatus != OrderItemStatusEnums.Cancelled)
                {
                    orderDetail.OrderItemStatus = OrderItemStatusEnums.Shipping;
                    _unitOfWork.OrderDetailsRepository.Update(orderDetail);
                }
            }

            _unitOfWork.OrderRepository.Update(order);
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            _logger.LogInformation("Hoàn tất xử lý chuyển trạng thái đơn hàng {OrderId} sang vận chuyển", request.OrderId);

            return new ChangeOrderStatusToShippingResponse(
                order.Id,
                ghnResponse.OrderCode,
                order.ShippingStatus.Status.Value
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Lỗi khi xử lý chuyển trạng thái đơn hàng {OrderId} sang vận chuyển", request.OrderId);
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}