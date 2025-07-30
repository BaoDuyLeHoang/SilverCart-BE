using MediatR;
using Newtonsoft.Json.Linq;
using SilverCart.Application.Services.System;

namespace SilverCart.Application.Features.Address.Queries.GetDistricts;

public record GetDistrictsByProvinceIdQuery(int ProvinceId) : IRequest<JToken>;

public class GetDistrictsByProvinceIdQueryHandler : IRequestHandler<GetDistrictsByProvinceIdQuery, JToken>
{
    private readonly IGhnService _ghnService;

    public GetDistrictsByProvinceIdQueryHandler(IGhnService ghnService)
    {
        _ghnService = ghnService;
    }

    public async Task<JToken> Handle(GetDistrictsByProvinceIdQuery request, CancellationToken cancellationToken)
    {
        return await _ghnService.GetDistricts(request.ProvinceId);
    }
}