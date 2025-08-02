using Infrastructures;
using Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderItemsStateGuardianConfirm;
using Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderItemsToStoreConfirm;
using Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderStatusToShipping;
using Infrastructures.Features.Orders.Commands.Create;
using Infrastructures.Features.Orders.Commands.Update.UpdateOrderDetail;
using Infrastructures.Features.Orders.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SilverCart.Application.Features.Orders.Queries.Shipping.CalculateShippingFee;
using SilverCart.Application.Features.Orders.Queries.Shipping.GetShippingServices;
using Infrastructures.Commons.Paginations;
using Newtonsoft.Json.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateOrderResponse>> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<GetAllOrdersResponse>>> GetAllOrders([FromQuery] GetAllOrdersQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetOrderByIdResponse>> GetOrderById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(result);
        }

        [HttpPut("guardian-confirm")]
        public async Task<ActionResult<bool>> ChangeOrderItemsToGuardianConfirm([FromBody] ChangeOrderItemsStateProductOfGuardianCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("store-confirm")]
        public async Task<ActionResult<bool>> ChangeOrderItemsToStoreConfirm([FromBody] ChangeOrderItemsToStoreConfirmCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("ship")]
        public async Task<ActionResult<bool>> ChangeOrderItemsToShip([FromBody] ChangeOrderStatusToShippingCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("details")]
        public async Task<ActionResult<bool>> ChangeOrderDetails([FromBody] UpdateOrderDetailsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("shipping/calculate-fee")]
        public async Task<ActionResult<CalculateShippingFeeResponse>> CalculateShippingFee([FromQuery] CalculateShippingFeeQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("shipping/services")]
        public async Task<ActionResult<JObject>> GetShippingServices([FromQuery] GetShippingServicesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
