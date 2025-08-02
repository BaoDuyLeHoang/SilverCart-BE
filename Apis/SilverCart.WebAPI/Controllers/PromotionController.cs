using DocumentFormat.OpenXml.Office2010.Excel;
using Infrastructures.Commons.Paginations;
using Infrastructures.Features.Categories.Queries.GetById;
using Infrastructures.Features.Promotions.Command.Create.CreateProductPromotion;
using Infrastructures.Features.Promotions.Command.Create.CreatePromotion;
using Infrastructures.Features.Promotions.Command.Deactive;
using Infrastructures.Features.Promotions.Command.Delete.DeletePromotion;
using Infrastructures.Features.Promotions.Command.Delete.Infrastructures.Features.Promotions.Command.Delete.DeleteProductPromotions;
using Infrastructures.Features.Promotions.Command.Update.UpdatePromotion;
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

<<<<<<< HEAD
        [HttpGet("{userId}")]
        [Authorize(Roles = "SuperAdmin,Admin,ShopOwner")]
=======
//        /promotion/{id}
        [HttpGet("a/{userId:Guid}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
>>>>>>> fc9d1f9ab862665cf993f6c886d7e3a55bbdfbb8
        public async Task<ActionResult<List<GetPromotionByIdResponse>>> GetAllPromotionsByUserId(Guid userId)
        {

            var result = await _mediator.Send(new GetPromotionByUserIdQuery(userId));
            return Ok(result);
        }
//        /promotion/{id}

        [HttpGet("{id:Guid}")]
        [Authorize(Roles = "SuperAdmin,Admin,ShopOwner")]
        public async Task<ActionResult<GetPromotionByIdResponse>> GetPromotionById(Guid? id)
        {
            var result = await _mediator.Send(new GetPromotionByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin,Admin,ShopOwner")]
        public async Task<ActionResult<PagedResult<GetAllPromotionsResponse>>> GetAllPromotions([FromQuery] GetAllPromotionsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin,ShopOwner")]
        public async Task<ActionResult<CreatePromotionResponse>> CreatePromotion([FromBody] CreatePromotionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("{promotionId}/add-products-to-promotion")]
        [Authorize(Roles = "Admin,SuperAdmin,ShopOwner")]
        public async Task<IActionResult> AddProductsToPromotionAsync(Guid promotionId, [FromBody] List<Guid> productIds)
        {
            await _mediator.Send(new AddProductToPromotionCommand(promotionId, productIds));
            return Ok(new { message = "Sản phẩm đã được thêm vào khuyến mãi thành công." });
        }

        [HttpPut("update-promotion")]
        [Authorize(Roles = "Admin,SuperAdmin,ShopOwner")]
        public async Task<ActionResult<UpdatePromotionResponse>> UpdatePromotion([FromBody] UpdatePromotionCommand command)
        {

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("product-promotions")]
        [Authorize(Roles = "SuperAdmin,Admin,ShopOwner")]
        public async Task<IActionResult> DeleteProductPromotions([FromBody] DeleteProductPromotionsCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "SuperAdmin,Admin,ShopOwner")]
        public async Task<IActionResult> DeletePromotion(Guid id)
        {
            try
            {
                var command = new DeletePromotionCommand(id);
                var result = await _mediator.Send(command);
                return result
                    ? Ok(new { Message = "Xóa chương trình khuyến mãi thành công." })
                    : BadRequest(new { Message = "Không thể xóa chương trình khuyến mãi." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("{id}/activate")]
        [Authorize(Roles = "SuperAdmin,Admin,ShopOwner")]
        public async Task<IActionResult> ActivatePromotion(Guid id)
        {
            var command = new ActivePromotionCommand(id);

            var result = await _mediator.Send(command);

            if (!result)
                return BadRequest("Failed to activate the promotion.");

            return Ok("Promotion activated successfully.");
        }
    }

}
