using AutoMapper;
using SilverCart.Application.Features.Orders.Queries.Shipping.CalculateShippingFee;
using SilverCart.Application.Services.System;

namespace SilverCart.Application.Features.Orders.Queries.Shipping.CalculateShippingFee;

public class CalculateShippingFeeMapper : Profile
{
    public CalculateShippingFeeMapper() => CreateMap<ShippingFeeResponse, CalculateShippingFeeResponse>();
}