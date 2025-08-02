using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using SilverCart.Application.Features.Address.Queries.GetProvinces;
using SilverCart.Application.Features.Address.Queries.GetDistricts;
using SilverCart.Application.Features.Address.Queries.GetWards;
using Newtonsoft.Json.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseController
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("provinces")]
        public async Task<ActionResult<JObject>> GetProvinces()
        {
            var result = await _mediator.Send(new GetProvincesQuery());
            return Ok(result);
        }

        [HttpGet("districts/{provinceId}")]
        public async Task<ActionResult<JObject>> GetDistrictsByProvinceId([FromRoute] int provinceId)
        {
            var result = await _mediator.Send(new GetDistrictsByProvinceIdQuery(provinceId));
            return Ok(result);
        }

        [HttpGet("wards/{districtId}")]
        public async Task<ActionResult<JObject>> GetWardsByDistrictId([FromRoute] int districtId)
        {
            var result = await _mediator.Send(new GetWardsByDistrictIdQuery(districtId));
            return Ok(result);
        }
    }
}