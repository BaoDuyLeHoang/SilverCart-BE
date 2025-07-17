using Infrastructures.Features.Stores.Commands.Create.CreateStore;
using Infrastructures.Features.Stores.Commands.Update.UpdateStore;
using Infrastructures.Features.Stores.Queries.GetMyStore;
using Infrastructures.Features.Users.Commands.Create.CreateStoreUser;
using Infrastructures.Features.Users.Queries.GetStoreUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController(IMediator mediator) : BaseController
    {
        private readonly IMediator _mediator = mediator;
        [HttpPost]
        public async Task<IActionResult> CreateStore([FromBody] CreateStoreCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStore([FromBody] UpdateStoreCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("employees")]
        public async Task<IActionResult> CreateStoreEmployee([FromBody] CreateStoreEmployeeCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetStoreEmployees([FromQuery] GetStoreUserQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("my-store")]
        public async Task<IActionResult> GetMyStore()
        {
            var result = await _mediator.Send(new GetMyStoreQueryCommand());
            return Ok(result);
        }
        //[HttpGet("order-items")]
        //public async Task<IActionResult> GetShopOrderItems([FromQuery] GetShopOrderItemsCommand request)
        //{
        //    var result = await _mediator.Send(request);
        //    return Ok(result);
        //}
    }
}
