using Infrastructures;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SilverCart.Application.Features.Promotions.Queries.GetUserPromotions;
using SilverCart.Application.Features.Promotions.Queries.GetAvailablePromotions;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : BaseController
    {
        private readonly IMediator _mediator;

        public PromotionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lấy danh sách khuyến mãi của người dùng
        /// </summary>
        /// <returns>Danh sách khuyến mãi</returns>
        [HttpGet("user-promotions")]
        public async Task<ActionResult<GetUserPromotionsResponse>> GetUserPromotions()
        {
            var result = await _mediator.Send(new GetUserPromotionsQuery());
            return Ok(result);
        }

        /// <summary>
        /// Lấy danh sách khuyến mãi có sẵn
        /// </summary>
        /// <returns>Danh sách khuyến mãi có sẵn</returns>
        [HttpGet("available")]
        public async Task<ActionResult<GetAvailablePromotionsResponse>> GetAvailablePromotions()
        {
            var result = await _mediator.Send(new GetAvailablePromotionsQuery());
            return Ok(result);
        }
    }
}