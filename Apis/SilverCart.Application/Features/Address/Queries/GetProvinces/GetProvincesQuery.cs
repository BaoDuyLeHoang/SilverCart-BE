using MediatR;
using Newtonsoft.Json.Linq;
using SilverCart.Application.Services.System;

namespace SilverCart.Application.Features.Address.Queries.GetProvinces;

public record GetProvincesQuery() : IRequest<JArray>;

public class GetProvincesQueryHandler : IRequestHandler<GetProvincesQuery, JArray>
{
    private readonly IGhnService _ghnService;

    public GetProvincesQueryHandler(IGhnService ghnService)
    {
        _ghnService = ghnService;
    }

    public async Task<JArray> Handle(GetProvincesQuery request, CancellationToken cancellationToken)
    {
        var response = await _ghnService.GetProvinces();

        // If response is already a JArray, return it
        if (response is JArray array)
            return array;

        return new JArray();
    }
}