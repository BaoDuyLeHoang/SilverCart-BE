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

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController(IMediator mediator) : BaseController
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("total-orders")]
        public async Task<IActionResult> GetTotalOrders([FromQuery] GetTotalOrdersCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("total-products")]
        public async Task<IActionResult> GetTotalProducts([FromQuery] GetTotalProductsCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("total-customers")]
        public async Task<IActionResult> GetTotalCustomers([FromQuery] GetTotalCustomerCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("total-revenues")]
        public async Task<IActionResult> GetTotalRevenues([FromQuery] GetTotalRevenuesCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("top-n-products")]
        public async Task<IActionResult> GetTopNProducts([FromQuery] GetTopNProductCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("top-n-customers")]
        public async Task<IActionResult> GetTopNCustomers([FromQuery] GetTopNCustomerCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("current-statistics")]
        public async Task<IActionResult> GetCurrentStatistics()
        {
            var result = await _mediator.Send(new GetCurrentStatisticCommand());
            return Ok(result);
        }
    }
}