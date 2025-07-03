using Infrastructures.Features.Consultation.CreateConsulationReport;
using Infrastructures.Interfaces.System;
using MediatR;
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateConsultant([FromBody] CreateConsultantCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new { ConsultantId = result });
        }

        [HttpPost("start-call")]
        public async Task<IActionResult> StartCall(Guid userId, string role)
        {
            var token = await _stringeeService.GenerateAccessTokenAsync(userId, role);
            return Ok(new { AccessToken = token });
        }
    }
}
