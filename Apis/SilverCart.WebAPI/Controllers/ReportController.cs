using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures;
using Infrastructures.Features.Reports.Command.Add;
using Infrastructures.Features.Reports.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : BaseController
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Guid>> AddReport([FromForm] AddReportCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid report data.");
            }
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(AddReport), new { id = result }, result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllReport([FromQuery] GetAllReportQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
