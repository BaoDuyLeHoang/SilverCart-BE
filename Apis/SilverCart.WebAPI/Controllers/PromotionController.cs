using DocumentFormat.OpenXml.Office2010.Excel;
using Infrastructures.Commons.Paginations;
using Infrastructures.Features.Categories.Queries.GetById;
using Infrastructures.Features.Promotions.Queries.GetAll;
using Infrastructures.Features.Promotions.Queries.GetById;
using Infrastructures.Features.Promotions.Queries.GetById.Infrastructures.Features.Promotions.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : Controller
    {
        private readonly IMediator _mediator;

        public PromotionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<ActionResult<List<GetPromotionByIdResponse>>> GetAllPromotionsByUserId(Guid userId)
        {

            var result = await _mediator.Send(new GetPromotionByUserIdQuery(userId));
            return Ok(result);
        }
        [HttpGet("{id:Guid}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<ActionResult<GetPromotionByIdResponse>> GetPromotionById(Guid? id)
        {
            var result = await _mediator.Send(new GetPromotionByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<ActionResult<PagedResult<GetAllPromotionsResponse>>> GetAllPromotions([FromQuery] GetAllPromotionsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }

}
