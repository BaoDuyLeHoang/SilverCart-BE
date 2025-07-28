using MediatR;
using Microsoft.AspNetCore.Mvc;
using SilverCart.Application.Features.Address.Queries.GetProvinces;
using SilverCart.Application.Features.Address.Queries.GetDistricts;
using SilverCart.Application.Features.Address.Queries.GetWards;
using WebAPI.Controllers;

namespace SilverCart.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : BaseController
{
    private readonly IMediator _mediator;

    public AddressController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // get Province , District , Ward
    [HttpGet("provinces")]
    public async Task<IActionResult> GetProvinces()
    {
        var result = await _mediator.Send(new GetProvincesQuery());
        return Ok(result);
    }

    // get Districts by ProvinceId
    [HttpGet("districts/{provinceId}")]
    public async Task<IActionResult> GetDistrictsByProvinceId([FromRoute] int provinceId)
    {
        var result = await _mediator.Send(new GetDistrictsByProvinceIdQuery(provinceId));
        return Ok(result);
    }

    // get Wards by DistrictId
    [HttpGet("wards/{districtId}")]
    public async Task<IActionResult> GetWardsByDistrictId([FromRoute] int districtId)
    {
        var result = await _mediator.Send(new GetWardsByDistrictIdQuery(districtId));
        return Ok(result);
    }

}