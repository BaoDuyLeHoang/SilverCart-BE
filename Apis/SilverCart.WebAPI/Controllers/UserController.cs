using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures;
using Infrastructures.Features.Users.Queries.GetAllUsers;
using Infrastructures.Features.Users.Queries.GetDependantUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Infrastructures.Commons.Paginations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : BaseController
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy danh sách người dùng thành công", typeof(PagedResult<GetAllUsersResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("dependent-users")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy danh sách người phụ thuộc thành công", typeof(List<Infrastructures.Features.Users.Queries.GetDependantUser.GetDependentUserResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetDependentUsers([FromQuery] GetDependentUserQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("update-profile")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cập nhật thông tin người dùng thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy người dùng")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserProfileCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("guardian-users")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy danh sách người giám hộ thành công", typeof(List<GetGuardianUserResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetGuardianUsers([FromQuery] GetGuardianUserQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}