using MediatR;
using SilverCart.Application.Services.System;
using SilverCart.Domain.Enums;
using Infrastructures;
using Infrastructures.Commons.Exceptions;
using SilverCart.Domain.Entities.Products;
using AutoMapper;

namespace SilverCart.Application.Features.Orders.Queries.Shipping.CalculateShippingFee;

public class CalculateShippingFeeHandler : IRequestHandler<CalculateShippingFeeQuery, CalculateShippingFeeResponse>
{
    private readonly IGhnService _ghnService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CalculateShippingFeeHandler(IGhnService ghnService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _ghnService = ghnService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CalculateShippingFeeResponse> Handle(CalculateShippingFeeQuery request, CancellationToken cancellationToken)
    {

        var fromAddress = await _unitOfWork.AddressRepository.GetStoreAddressByStoreIdAsync(request.OrderInfo.FormStoreId);
        var toAddress = await _unitOfWork.AddressRepository.GetByIdAsync(request.OrderInfo.ToAddressId);
        AppExceptions.ThrowIfNotFound(toAddress, "Address not found");

        var toWardCode = toAddress.WardCode;
        var toDistrictId = toAddress.DistrictId;

        var productItems = new List<ProductItem>();
        foreach (var item in request.ProductItems)
        {
            var productItem = await _unitOfWork.ProductItemRepository.GetByIdAsync(item.ProductItemId, x => x.Variant);
            AppExceptions.ThrowIfNotFound(productItem, "Product item not found");
            var product = await _unitOfWork.ProductItemRepository.GetProductByProductItemID(item.ProductItemId);
            productItem.ProductName = product.Name;
            productItems.Add(productItem);
        }

        var weight = productItems.Sum(item => item.Weight);
        var length = productItems.Sum(item => item.Length);
        var width = productItems.Sum(item => item.Width);
        var height = productItems.Sum(item => item.Height);
        var insuranceValue = (int)productItems.Select((x, index) => x.DiscountedPrice * request.ProductItems[index].Quantity).Sum();
        var coupon = request.UserPromotionId?.ToString();

        var items = productItems.Select((item, index) => new ShippingFeeItem
        {
            Name = item.ProductName + " - " + item.Value,
            Quantity = request.ProductItems[index].Quantity,
            Weight = item.Weight,
            Length = item.Length,
            Width = item.Width,
            Height = item.Height
        }).ToList();

        ShippingFeeResponse shippingFeeResponse = await _ghnService.CalculateShippingFee(new CalculateShippingFeeRequest
        {
            FromDistrictId = fromAddress.DistrictId,
            FromWardCode = fromAddress.WardCode,
            ToWardCode = toWardCode,
            ToDistrictId = toDistrictId,
            Weight = weight,
            Length = length,
            Width = width,
            Height = height,
            InsuranceValue = insuranceValue,
            Coupon = coupon,
            Items = items
        });
        return _mapper.Map<CalculateShippingFeeResponse>(shippingFeeResponse);
    }
}