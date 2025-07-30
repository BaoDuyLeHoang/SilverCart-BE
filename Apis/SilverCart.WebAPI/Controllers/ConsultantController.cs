using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<Guid>> CreateConsultant([FromBody] CreateConsultantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new { ConsultantId = result });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create-consultant")]
        public async Task<ActionResult<Guid>> CreateConsultantReport([FromBody] CreateConsultantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new { ReportId = result });
        }

        [Authorize(Roles = "Customer, DependentUser")]
        [HttpPost("start-call")]
        public async Task<ActionResult<string>> StartCall(Guid userId, string role)
        {
            var token = await _stringeeService.GenerateAccessTokenAsync(userId, role);
            return Ok(new { AccessToken = token });
        }

        [Authorize(Roles = "Consultant")]
        [HttpPost("create-consultation-report")]
        public async Task<ActionResult<bool>> Create([FromBody] CreateConsultationReportCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok(new { message = "Report created successfully." }) : BadRequest("Failed to create report.");
        }

        [Authorize(Roles = "Consultant")]
        [HttpPut("update-consultation-report")]
        public async Task<ActionResult<bool>> Update([FromBody] UpdateConsultationReportCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok(new { message = "Report updated successfully." }) : NotFound("Consultation not found.");
        }
    }
}
