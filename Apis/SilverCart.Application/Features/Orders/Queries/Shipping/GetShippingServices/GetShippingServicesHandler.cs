using MediatR;
using Newtonsoft.Json.Linq;
using SilverCart.Application.Services.System;

namespace SilverCart.Application.Features.Orders.Queries.Shipping.GetShippingServices;


public class GetShippingServicesHandler : IRequestHandler<GetShippingServicesQuery, JToken>
{
    private readonly IGhnService _ghnService;

    public GetShippingServicesHandler(IGhnService ghnService)
    {
        _ghnService = ghnService;
    }

    public async Task<JToken> Handle(GetShippingServicesQuery request, CancellationToken cancellationToken)
    {
        return await _ghnService.GetServices(request.FromDistrictId, request.ToDistrictId);
    }
}