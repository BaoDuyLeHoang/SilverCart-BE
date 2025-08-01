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
using Infrastructures.Features.Statistics.Queries.GetTotal.GetTotalTransactions;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController(IMediator mediator) : BaseController
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("total-orders")]
        public async Task<ActionResult<List<GetTotalOrdersQueryResponse>>> GetTotalOrders([FromQuery] GetTotalOrdersCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("total-products")]
        public async Task<ActionResult<List<GetTotalProductsQueryResponse>>> GetTotalProducts([FromQuery] GetTotalProductsCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("total-customers")]
        public async Task<ActionResult<List<GetTotalCustomerQueryResponse>>> GetTotalCustomers([FromQuery] GetTotalCustomerCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("total-revenues")]
        public async Task<ActionResult<List<GetTotalRevenuesQueryResponse>>> GetTotalRevenues([FromQuery] GetTotalRevenuesCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("top-n-products")]
        public async Task<ActionResult<GetTopNProductQueryResponse>> GetTopNProducts([FromQuery] GetTopNProductCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("top-n-customers")]
        public async Task<ActionResult<GetTopNCustomerQueryResponse>> GetTopNCustomers([FromQuery] GetTopNCustomerCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("current-statistics")]
        public async Task<ActionResult<GetCurrentStatisticQueryResponse>> GetCurrentStatistics()
        {
            var result = await _mediator.Send(new GetCurrentStatisticCommand());
            return Ok(result);
        }

        [HttpGet("total-transactions")]
        public async Task<ActionResult<List<GetTotalNumberOfTransactionsQuery>>> GetTotalTransactions([FromQuery] GetTotalNumberOfTransactionsQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}