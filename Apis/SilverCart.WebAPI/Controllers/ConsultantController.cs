using Infrastructures.Features.Consultation.Consultant.Create;
using Infrastructures.Features.Consultation.ConsultationReport;
using Infrastructures.Features.Consultation.ConsultationReport.Update;
using Infrastructures.Interfaces.System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
<<<<<<< HEAD
=======
using Infrastructures.Features.Consultation.CreateConsulationReport;
using Infrastructures.Interfaces.System;
using MediatR;
>>>>>>> 5206121e8a06e53f0fae7d179eaeaed89efa9237
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> CreateConsultant([FromBody] CreateConsultantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new { ConsultantId = result });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create-consultant")]
        public async Task<IActionResult> CreateConsultantReport([FromBody] Infrastructures.Features.Consultation.CreateConsulationReport.CreateConsultantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new { ReportId = result });
        }

        [Authorize(Roles = "Customer, DependentUser")]
        [HttpPost("start-call")]
        public async Task<IActionResult> StartCall(Guid userId, string role)
        {
            var token = await _stringeeService.GenerateAccessTokenAsync(userId, role);
            return Ok(new { AccessToken = token });
        }

        [Authorize(Roles = "Consultant")]
        [HttpPost("create-consultation-report")]
        public async Task<IActionResult> Create([FromBody] CreateConsultationReportCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok(new { message = "Report created successfully." }) : BadRequest("Failed to create report.");
        }


        [Authorize(Roles = "Consultant")]
        [HttpPut("update-consultation-report")]
        public async Task<IActionResult> Update([FromBody] UpdateConsultationReportCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok(new { message = "Report updated successfully." }) : NotFound("Consultation not found.");
        }
    }
}
