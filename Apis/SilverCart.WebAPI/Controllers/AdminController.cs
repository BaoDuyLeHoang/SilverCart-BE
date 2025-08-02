using Infrastructures.Features.Admin.Queries.Promotion;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : BaseController
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("promotion-detail")]
        public async Task<IActionResult> GetPromotionDetail([FromQuery] GetPromotionDetailQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
