using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Infrastructures.Features.Carts.Commands.AddCart;
using Infrastructures.Features.Carts.Queries.GetCart;
using Infrastructures.Features.Carts.Commands.UpdateCart;
using Infrastructures.Features.Carts.Commands.DeleteCart;
using Infrastructures.Features.Carts.Commands.GetCartItem;
using Infrastructures.Features.Carts.Commands.UpdateCartItem;
using Infrastructures.Features.Carts.Commands.RemoveCartItem;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "CustomerUser,GuardianUser")]
public class CartController : BaseController
{
    private readonly IMediator _mediator;

    public CartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Tạo mới giỏ hàng với các items
    /// </summary>
    /// <param name="command">Thông tin giỏ hàng cần tạo</param>
    /// <returns>Thông tin giỏ hàng đã tạo</returns>
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<AddCartResponse>> AddCart([FromBody] AddCartCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }


    /// <summary>
    /// Lấy thông tin giỏ hàng theo CartId
    /// </summary>
    /// <param name="cartId">ID của giỏ hàng</param>
    /// <returns>Thông tin giỏ hàng và danh sách items</returns>
    [HttpGet("{cartId}")]
    [Authorize]
    public async Task<ActionResult<GetCartResponse>> GetCart([FromRoute] Guid cartId)
    {
        var result = await _mediator.Send(new GetCartQuery(cartId));
        return Ok(result);
    }

    /// <summary>
    /// Cập nhật thông tin giỏ hàng
    /// </summary>
    /// <param name="cartId">ID của giỏ hàng</param>
    /// <param name="command">Thông tin cập nhật</param>
    /// <returns>Thông tin giỏ hàng đã cập nhật</returns>
    [HttpPut("{cartId}")]
    [Authorize]
    public async Task<ActionResult<UpdateCartResponse>> UpdateCart(
        [FromRoute] Guid cartId,
        [FromBody] UpdateCartCommand command)
    {
        var updatedCommand = command with { CartId = cartId };
        var result = await _mediator.Send(updatedCommand);
        return Ok(result);
    }

    /// <summary>
    /// Xóa giỏ hàng
    /// </summary>
    /// <param name="cartId">ID của giỏ hàng cần xóa</param>
    /// <returns>Kết quả xóa</returns>
    [HttpDelete("{cartId}")]
    [Authorize]
    public async Task<ActionResult<bool>> DeleteCart([FromRoute] Guid cartId)
    {
        var command = new DeleteCartCommand(cartId);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Lấy thông tin cart item theo CartItemId
    /// </summary>
    /// <param name="cartItemId">ID của cart item</param>
    /// <returns>Thông tin cart item</returns>
    [HttpGet("items/{cartItemId}")]
    [Authorize]
    public async Task<ActionResult<GetCartItemResponse>> GetCartItem([FromRoute] Guid cartItemId)
    {
        var result = await _mediator.Send(new GetCartItemCommand(cartItemId));
        return Ok(result);
    }

    /// <summary>
    /// Cập nhật thông tin cart item
    /// </summary>
    /// <param name="cartItemId">ID của cart item</param>
    /// <param name="command">Thông tin cập nhật</param>
    /// <returns>Thông tin cart item đã cập nhật</returns>
    [HttpPut("items/{cartItemId}")]
    [Authorize]
    public async Task<ActionResult<UpdateCartItemResponse>> UpdateCartItem(
        [FromRoute] Guid cartItemId,
        [FromBody] UpdateCartItemCommand command)
    {
        var updatedCommand = command with { CartItemId = cartItemId };
        var result = await _mediator.Send(updatedCommand);
        return Ok(result);
    }

    /// <summary>
    /// Xóa cart item
    /// </summary>
    /// <param name="cartItemId">ID của cart item cần xóa</param>
    /// <returns>Kết quả xóa</returns>
    [HttpDelete("items/{cartItemId}")]
    [Authorize]
    public async Task<ActionResult<bool>> RemoveCartItem([FromRoute] Guid cartItemId)
    {
        var command = new RemoveCartItemCommand(cartItemId);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}