using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using Infrastructures.Features.Consultation.Consultant.Create;
using Infrastructures.Features.Consultation.Consultant.Update;
using Infrastructures.Features.Consultation.ConsultationReport;
using Infrastructures.Features.Consultation.ConsultationReport.Update;
using Infrastructures.Interfaces.System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IStringeeService _stringeeService;

        public ConsultantController(IMediator mediator, IStringeeService stringeeService)
        {
            _mediator = mediator;
            _stringeeService = stringeeService;
        }

        [Authorize(Roles = "Consultant")]
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Tạo tư vấn viên thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Không có quyền truy cập")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> CreateConsultant([FromBody] CreateConsultantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new { ConsultantId = result });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create-consultant")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tạo tư vấn viên thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Không có quyền truy cập")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> CreateConsultantReport([FromBody] CreateConsultantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new { ReportId = result });
        }

        [Authorize(Roles = "Customer, DependentUser")]
        [HttpPost("start-call")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tạo token cuộc gọi thành công", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Không có quyền truy cập")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> StartCall(Guid userId, string role)
        {
            var token = await _stringeeService.GenerateAccessTokenAsync(userId, role);
            return Ok(new { AccessToken = token });
        }

        [Authorize(Roles = "Consultant")]
        [HttpPost("create-consultation-report")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tạo báo cáo tư vấn thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Không có quyền truy cập")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> Create([FromBody] CreateConsultationReportCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok(new { message = "Report created successfully." }) : BadRequest("Failed to create report.");
        }

        [Authorize(Roles = "Consultant")]
        [HttpPut("update-consultation-report")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cập nhật báo cáo tư vấn thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Không có quyền truy cập")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy báo cáo tư vấn")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> Update([FromBody] UpdateConsultationReportCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok(new { message = "Report updated successfully." }) : NotFound("Consultation not found.");
        }
    }
}
