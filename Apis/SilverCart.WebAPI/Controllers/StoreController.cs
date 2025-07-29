using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures;
using Infrastructures.Features.Stores.Commands.Create.CreateStore;
using Infrastructures.Features.Stores.Commands.Update.UpdateStore;
using Infrastructures.Features.Stores.Queries.GetMyStore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : BaseController
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Tạo cửa hàng thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Không có quyền truy cập")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> CreateStore([FromBody] CreateStoreCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, "Cập nhật thông tin cửa hàng thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Không có quyền truy cập")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy cửa hàng")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> UpdateStore([FromBody] UpdateStoreCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("my-store")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy thông tin cửa hàng thành công", typeof(GetMyStoreQueryResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy cửa hàng")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetMyStore()
        {
            var result = await _mediator.Send(new GetMyStoreQueryCommand());
            return Ok(result);
        }
    }
}
