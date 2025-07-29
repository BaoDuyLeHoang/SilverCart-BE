using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Infrastructures.Features.Stores.Commands.Create.CreateStore;
using SilverCart.Infrastructure.Commons;

namespace SilverCart.Application.Services.System;


public class GhnService : IGhnService
{
    private readonly HttpClient _httpClient;
    private readonly string _token;
    private readonly int _shopId;
    private readonly string _baseUrl;
    private JsonSerializer _serializer;


    public GhnService(AppConfiguration configuration)
    {
        _token = configuration.Ghn?.TokenAPI ?? throw new ArgumentNullException("GHN Token is missing");
        _shopId = configuration.Ghn?.ShopId ?? throw new ArgumentNullException("GHN ShopId is missing");
        _baseUrl = configuration.Ghn?.BaseUrl ?? throw new ArgumentNullException("GHN BaseUrl is missing");

        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(_baseUrl)
        };
        _httpClient.DefaultRequestHeaders.Add("Token", _token);
        _serializer = JsonSerializer.Create(new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        });
    }

    public async Task<ShippingFeeResponse> CalculateShippingFee(CalculateShippingFeeRequest request)
    {
        try
        {
            // Add ShopId header for fee calculation
            _httpClient.DefaultRequestHeaders.Remove("ShopId");
            _httpClient.DefaultRequestHeaders.Add("ShopId", _shopId.ToString());
            // Convert request to match GHN API format
            var ghnRequest = JObject.FromObject(request, _serializer);
            var result = await PostAsync("/shiip/public-api/v2/shipping-order/fee", ghnRequest);
            return result.ToObject<ShippingFeeResponse>(_serializer);
        }
        catch (Exception ex)
        {
            throw new Exception($"Thất Bại tính phí vận chuyển: {ex.Message}");
        }
    }

    public async Task<CreateOrderResponse> CreateShippingOrder(GhnCreateOrderRequest request)
    {
        try
        {
            // Add ShopId header for create order request
            _httpClient.DefaultRequestHeaders.Remove("ShopId");
            _httpClient.DefaultRequestHeaders.Add("ShopId", _shopId.ToString());

            // Convert request to match GHN API format
            var ghnRequest = JObject.FromObject(request, _serializer);

            var result = await PostAsync("/shiip/public-api/v2/shipping-order/create", ghnRequest);
            return result.ToObject<CreateOrderResponse>(_serializer);
        }
        catch (Exception ex)
        {
            throw new Exception($"Thất Bại tạo đơn hàng: {ex.Message}");
        }
    }

    public async Task<JToken> GetProvinces()
    {
        try
        {
            var response = await GetAsync("/shiip/public-api/master-data/province");

            if (response == null)
                return new JArray();
            return response as JArray;
        }
        catch (Exception ex)
        {
            throw new Exception($"Thất Bại lấy tỉnh thành: {ex.Message}");
        }
    }

    public async Task<JToken> GetDistricts(int provinceId)
    {
        try
        {
            var response = await GetAsync($"/shiip/public-api/master-data/district?province_id={provinceId}");

            // Ensure we have a valid response
            if (response == null)
                return new JArray();

            // If response is already a JArray, return it
            if (response is JArray array)
                return array;

            // If response is a JObject with a "districts" property that's an array
            if (response is JObject obj && obj["districts"] is JArray districts)
                return districts;

            // If we can't find a valid array structure, return empty array
            return new JArray();
        }
        catch (Exception ex)
        {
            throw new Exception($"Thất Bại lấy quận huyện: {ex.Message}");
        }
    }

    public async Task<JToken> GetWards(int districtId)
    {
        try
        {
            var response = await GetAsync($"/shiip/public-api/master-data/ward?district_id={districtId}");

            // Ensure we have a valid response
            if (response == null)
                return new JArray();

            // If response is already a JArray, return it
            if (response is JArray array)
                return array;

            // If response is a JObject with a "wards" property that's an array
            if (response is JObject obj && obj["wards"] is JArray wards)
                return wards;

            // If we can't find a valid array structure, return empty array
            return new JArray();
        }
        catch (Exception ex)
        {
            throw new Exception($"Thất Bại lấy phường xã: {ex.Message}");
        }
    }

    public async Task<JToken> GetServices(int fromDistrictId, int toDistrictId)
    {
        try
        {
            var request = JObject.FromObject(new
            {
                shop_id = _shopId,
                from_district = fromDistrictId,
                to_district = toDistrictId
            }, _serializer);

            // Only Token header is needed for this API
            _httpClient.DefaultRequestHeaders.Remove("ShopId");

            var response = await PostAsync("/shiip/public-api/v2/shipping-order/available-services", request);

            // Ensure we have a valid response
            if (response == null)
                return new JArray();

            // If response is already a JArray, return it
            if (response is JArray array)
                return array;

            // If response is a JObject with a "services" property that's an array
            if (response is JObject obj && obj["services"] is JArray services)
                return services;

            // If we can't find a valid array structure, return empty array
            return new JArray();
        }
        catch (Exception ex)
        {
            throw new Exception($"Thất Bại lấy dịch vụ vận chuyển: {ex.Message}");
        }
    }

    public async Task<JToken> CancelOrder(string orderCode)
    {
        try
        {
            return await PostAsync("/shiip/public-api/v2/switch-status/cancel", new JObject
            {
                ["order_codes"] = new JArray { orderCode }
            });
        }
        catch (Exception ex)
        {
            throw new Exception($"Thất Bại hủy đơn hàng: {ex.Message}");
        }
    }

    public async Task<JToken> GetOrderInfo(string orderCode)
    {
        try
        {
            return await PostAsync("/shiip/public-api/v2/shipping-order/detail", new JObject
            {
                ["order_code"] = orderCode
            });
        }
        catch (Exception ex)
        {
            throw new Exception($"Thất Bại lấy thông tin đơn hàng: {ex.Message}");
        }
    }

    public async Task<int?> RegisterStoreAsync(CreateStoreGhnRequest createStoreGhnRequest)
    {
        try
        {
            var result = await PostAsync("/shiip/public-api/v2/shop/register", JObject.FromObject(createStoreGhnRequest, _serializer));
            return result["shop_id"]?.Value<int>();
        }
        catch (Exception ex)
        {
            throw new Exception($"Thất Bại đăng ký cửa hàng: {ex.Message}");
        }
    }

    private async Task<JToken> GetAsync(string endpoint)
    {
        var response = await _httpClient.GetAsync(endpoint);
        var content = await response.Content.ReadAsStringAsync();
        var json = JObject.Parse(content);

        if (json["code"]?.Value<int>() != 200)
        {
            throw new Exception(json["message"]?.Value<string>() ?? "Unknown error");
        }

        return json["data"] ?? new JObject();
    }

    private async Task<JToken> PostAsync(string endpoint, JObject data)
    {
        var response = await _httpClient.PostAsync(endpoint,
            new StringContent(data.ToString(), Encoding.UTF8, "application/json"));
        var content = await response.Content.ReadAsStringAsync();
        var json = JObject.Parse(content);

        if (json["code"]?.Value<int>() != 200)
        {
            throw new Exception(json["message"]?.Value<string>() ?? "Unknown error");
        }

        return json["data"] ?? new JObject();
    }
}

