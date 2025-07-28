using Infrastructures.Features.Reports.Command.Add;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        [HttpPost]
        public async Task<IActionResult> AddReport([FromForm] AddReportCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid report data.");
            }
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(AddReport), new { id = result }, result);
        }
    }
}
