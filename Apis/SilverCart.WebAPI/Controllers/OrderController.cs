using Infrastructures;
using Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderItemsStateGuardianConfirm;
using Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderItemsToStoreConfirm;
using Infrastructures.Features.Orders.Commands.ChangeState.ChangeOrderStatusToShipping;
using Infrastructures.Features.Orders.Commands.Create;
using Infrastructures.Features.Orders.Commands.Update.UpdateOrderDetail;
using Infrastructures.Features.Orders.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerResponse(StatusCodes.Status200OK, "Tạo đơn hàng thành công", typeof(CreateOrderResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy danh sách đơn hàng thành công", typeof(PagedResult<GetAllOrdersResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetAllOrders([FromQuery] GetAllOrdersQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy thông tin đơn hàng thành công", typeof(GetOrderByIdResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy đơn hàng")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(result);
        }

        [HttpPut("guardian-confirm")]
        [SwaggerResponse(StatusCodes.Status200OK, "Xác nhận đơn hàng thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy đơn hàng")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> ChangeOrderItemsToGuardianConfirm([FromBody] ChangeOrderItemsStateProductOfGuardianCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("store-confirm")]
        [SwaggerResponse(StatusCodes.Status200OK, "Xác nhận đơn hàng từ cửa hàng thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy đơn hàng")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> ChangeOrderItemsToStoreConfirm([FromBody] ChangeOrderItemsToStoreConfirmCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("ship")]
        [SwaggerResponse(StatusCodes.Status200OK, "Chuyển trạng thái đơn hàng sang đang giao thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy đơn hàng")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> ChangeOrderItemsToShip([FromBody] ChangeOrderStatusToShippingCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("details")]
        [SwaggerResponse(StatusCodes.Status200OK, "Cập nhật chi tiết đơn hàng thành công")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy đơn hàng")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> ChangeOrderDetails([FromBody] UpdateOrderDetailsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("shipping/calculate-fee")]
        [SwaggerResponse(StatusCodes.Status200OK, "Tính phí vận chuyển thành công", typeof(CalculateShippingFeeResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> CalculateShippingFee([FromQuery] CalculateShippingFeeQuery query)
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
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy danh sách dịch vụ vận chuyển thành công", typeof(JObject))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetShippingServices([FromQuery] GetShippingServicesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
