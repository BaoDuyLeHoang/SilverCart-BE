using Infrastructures.Commons.Exceptions;
using Infrastructures.Features.Stores.Commands.Create.CreateStore;
using Infrastructures.Interfaces.System;
using Microsoft.Extensions.Configuration;
using SilverCart.Domain.Enums;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructures.Services.System;
public class GhnService : IGhnService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public GhnService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<string> CreateOrderShippingAsync(CreateOrderShippingGhnRequest command)
    {
        if (command == null) throw new ArgumentNullException(nameof(command));

        var requestUrl = "https://dev-online-gateway.ghn.vn/shiip/public-api/v2/shipping-order/create";
        var token = _configuration["Ghn:TokenAPI"];

        if (string.IsNullOrEmpty(token))
            throw new AppExceptions("GHN Token is not configured.");

        var requestData = new
        {
            to_name = command.ToName,
            from_name = command.FromName,
            from_phone = command.FromPhone,
            from_address = command.FromAddress,
            from_ward_name = command.FromWardName,
            from_district_name = command.FromDistrictName,
            from_provice_name = command.FromProvinceName,
            to_phone = command.ToPhone,
            to_address = command.ToAddress,
            to_ward_code = command.ToWardCode,
            to_district_id = command.ToDistrictId,
            return_phone = command.ReturnPhone,
            return_address = command.ReturnAddress,
            return_district_id = command.ReturnDistrictId,
            return_ward_code = command.ReturnWardCode,
            client_order_code = command.ClientOrderCode,
            cod_amount = command.CodAmount,
            content = command.Content,
            weight = command.Weight,
            length = command.Length,
            width = command.Width,
            height = command.Height,
            service_type_id = command.ServiceTypeId,
            payment_type_id = command.PaymentTypeId,
            required_note = command.RequireNote,
            Items = command.OrderItems
        };

        var json = JsonSerializer.Serialize(requestData, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        Console.WriteLine("📦 GHN Request JSON:");
        Console.WriteLine(json);


        using var content = new StringContent(json, Encoding.UTF8, "application/json");

        using var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
        request.Content = content;
        request.Headers.Add("Token", token);
        request.Headers.Add("ShopId", command.ShopId.ToString());

        using var response = await _httpClient.SendAsync(request);
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception($"GHN API Error: {response.StatusCode}, {responseContent}");

        using var doc = JsonDocument.Parse(responseContent);
        var root = doc.RootElement;

        if (root.TryGetProperty("data", out var data) && data.TryGetProperty("order_code", out var orderCode))
        {
            return orderCode.GetString() ?? throw new Exception("Order code is null");
        }

        throw new Exception("Invalid response from GHN: order_code not found.");
    }


    public async Task<int> RegisterStoreAsync(CreateStoreGhnRequest vm)
    {
        if (vm == null) throw new ArgumentNullException(nameof(vm));

        var requestUrl = "https://dev-online-gateway.ghn.vn/shiip/public-api/v2/shop/register";
        var token = _configuration["Ghn:TokenAPI"];

        if (string.IsNullOrEmpty(token))
            throw new InvalidOperationException("GHN Token is not configured.");

        var requestData = new
        {
            name = vm.ShopName,
            phone = vm.ShopPhone,
            address = vm.ShopAddress,
            ward_code = vm.WardCode,
            district_id = vm.DistrictId
        };

        var json = JsonSerializer.Serialize(requestData);
        using var content = new StringContent(json, Encoding.UTF8, "application/json");

        using var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
        request.Content = content;
        request.Headers.Add("Token", token);

        using var response = await _httpClient.SendAsync(request);

        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception($"GHN API Error: {response.StatusCode}, {responseContent}");

        using var doc = JsonDocument.Parse(responseContent);
        var root = doc.RootElement;

        if (root.TryGetProperty("data", out var data) && data.TryGetProperty("shop_id", out var shopId))
        {
            return shopId.GetInt32();
        }

        throw new Exception("Invalid response from GHN: shop_id not found.");
    }
}
