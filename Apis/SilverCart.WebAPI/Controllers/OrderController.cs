﻿using Infrastructures;
using Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderItemsStateGuardianConfirm;
using Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderItemsToStoreConfirm;
using Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderStatusToShipping;
using Infrastructures.Features.Orders.Commands.Create;
using Infrastructures.Features.Orders.Commands.Update.UpdateOrderDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery] GetAllOrdersQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(result);
        }
        [HttpPut("guardian-confirm")]
        public async Task<IActionResult> ChangeOrderItemsToGuardianConfirm([FromBody] ChangeOrderItemsStateProductOfGuardianCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("store-confirm")]
        public async Task<IActionResult> ChangeOrderItemsToStoreConfirm([FromBody] ChangeOrderItemsToStoreConfirmCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("ship")]
        public async Task<IActionResult> ChangeOrderItemsToShip([FromBody] ChangeOrderStatusToShippingCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("details")]
        public async Task<IActionResult> ChangeOrderDetails([FromBody] UpdateOrderDetailsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        //[HttpPut("order-items")]
        //public async Task<IActionResult> ChangeOrderItemsToStoreConfirm([FromQuery] UpdateOrderItemsCommand command)
        //{
        //    var result = await _mediator.Send(command);
        //    return Ok(result);
        //}
    }
}
