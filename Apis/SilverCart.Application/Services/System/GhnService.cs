using Infrastructures.Features.Stores.Commands.Create.CreateStore;
using Infrastructures.Interfaces.System;
using Microsoft.Extensions.Configuration;
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
