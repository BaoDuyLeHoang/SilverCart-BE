using MediatR;
using Newtonsoft.Json.Linq;
using SilverCart.Application.Services.System;

namespace SilverCart.Application.Features.Address.Queries.GetWards;

public record GetWardsByDistrictIdQuery(int DistrictId) : IRequest<JToken>;

public class GetWardsByDistrictIdQueryHandler : IRequestHandler<GetWardsByDistrictIdQuery, JToken>
{
    private readonly IGhnService _ghnService;

    public GetWardsByDistrictIdQueryHandler(IGhnService ghnService)
    {
        _ghnService = ghnService;
    }

    public async Task<JToken> Handle(GetWardsByDistrictIdQuery request, CancellationToken cancellationToken)
    {
        return await _ghnService.GetWards(request.DistrictId);
    }
}