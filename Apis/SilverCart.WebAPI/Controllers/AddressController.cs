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
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy danh sách tỉnh/thành phố thành công", typeof(JObject))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetProvinces()
        {
            var result = await _mediator.Send(new GetProvincesQuery());
            return Ok(result);
        }

        [HttpGet("districts/{provinceId}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy danh sách quận/huyện thành công", typeof(JObject))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetDistrictsByProvinceId([FromRoute] int provinceId)
        {
            var result = await _mediator.Send(new GetDistrictsByProvinceIdQuery(provinceId));
            return Ok(result);
        }

        [HttpGet("wards/{districtId}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy danh sách phường/xã thành công", typeof(JObject))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetWardsByDistrictId([FromRoute] int districtId)
        {
            var result = await _mediator.Send(new GetWardsByDistrictIdQuery(districtId));
            return Ok(result);
        }
    }
}