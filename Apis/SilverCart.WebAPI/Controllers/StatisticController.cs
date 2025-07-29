using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Features.Statistics.Queries.GetCurrentStatistic;
using Infrastructures.Features.Statistics.Queries.GetTopN.GetTopNCustomer;
using Infrastructures.Features.Statistics.Queries.GetTopN.GetTopNProduct;
using Infrastructures.Features.Statistics.Queries.GetTotal.GetTotalCustomers;
using Infrastructures.Features.Statistics.Queries.GetTotal.GetTotalOrders;
using Infrastructures.Features.Statistics.Queries.GetTotal.GetTotalProducts;
using Infrastructures.Features.Statistics.Queries.GetTotal.GetTotalRevenues;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController(IMediator mediator) : BaseController
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("total-orders")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy tổng số đơn hàng thành công", typeof(List<GetTotalOrdersQueryResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetTotalOrders([FromQuery] GetTotalOrdersCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("total-products")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy tổng số sản phẩm thành công", typeof(List<GetTotalProductsQueryResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetTotalProducts([FromQuery] GetTotalProductsCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("total-customers")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy tổng số khách hàng thành công", typeof(List<GetTotalCustomerQueryResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetTotalCustomers([FromQuery] GetTotalCustomerCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("total-revenues")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy tổng doanh thu thành công", typeof(List<GetTotalRevenuesQueryResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetTotalRevenues([FromQuery] GetTotalRevenuesCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("top-n-products")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy danh sách sản phẩm bán chạy thành công", typeof(GetTopNProductQueryResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetTopNProducts([FromQuery] GetTopNProductCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("top-n-customers")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy danh sách khách hàng tiềm năng thành công", typeof(GetTopNCustomerQueryResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetTopNCustomers([FromQuery] GetTopNCustomerCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("current-statistics")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lấy thống kê hiện tại thành công", typeof(GetCurrentStatisticQueryResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
        public async Task<IActionResult> GetCurrentStatistics()
        {
            var result = await _mediator.Send(new GetCurrentStatisticCommand());
            return Ok(result);
        }
    }
}