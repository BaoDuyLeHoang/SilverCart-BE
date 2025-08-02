using MediatR;
using SilverCart.Application.Services.System;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;

namespace SilverCart.Application.Features.Orders.Queries.Shipping.CalculateShippingFee;

public record CalculateShippingFeeQuery(
    List<CalculateShippingFeeItemCommand> ProductItems,
    CalculateShippingFeeInfoCommand OrderInfo,
    Guid? UserPromotionId = null
    ) : IRequest<CalculateShippingFeeResponse>;
public record CalculateShippingFeeItemCommand(Guid ProductItemId, int Quantity);
public record CalculateShippingFeeInfoCommand(Guid FormStoreId, Guid ToAddressId, PaymentMethodEnum PaymentMethod);

public record CalculateShippingFeeResponse(
    decimal TotalPrice,
    decimal FinalPrice,
    decimal ServiceFee,
    decimal InsuranceFee,
    decimal PickStationFee,
    decimal CouponValue,
    decimal R2sFee,
    decimal DocumentReturn,
    decimal DoubleCheck,
    decimal CodFee,
    decimal PickRemoteAreasFee,
    decimal DeliverRemoteAreasFee,
    decimal CodFailedFee);
