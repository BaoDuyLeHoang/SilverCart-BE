using Infrastructures.Features.Stores.Commands.Create.CreateStore;
using Newtonsoft.Json.Linq;

namespace SilverCart.Application.Services.System;

public interface IGhnService
{
    Task<ShippingFeeResponse> CalculateShippingFee(CalculateShippingFeeRequest request);
    Task<CreateOrderResponse> CreateShippingOrder(GhnCreateOrderRequest request);
    Task<JToken> GetProvinces();
    Task<JToken> GetDistricts(int provinceId);
    Task<JToken> GetWards(int districtId);
    Task<JToken> GetServices(int fromDistrictId, int toDistrictId);
    Task<JToken> CancelOrder(string orderCode);
    Task<JToken> GetOrderInfo(string orderCode);
    Task<int?> RegisterStoreAsync(CreateStoreGhnRequest createStoreGhnRequest);
}

