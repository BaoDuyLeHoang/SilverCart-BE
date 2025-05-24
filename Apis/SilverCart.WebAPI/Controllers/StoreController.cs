using Infrastructures.Features.Orders.Queries.GetShopOrderItems;
using Infrastructures.Features.Stores.Commands.Create.CreateStore;
using Infrastructures.Features.Stores.Commands.Delete.DeleteStore;
using Infrastructures.Features.Stores.Commands.Update.UpdateStore;
using Infrastructures.Features.Stores.Queries.GetAll;
using Infrastructures.Features.Stores.Queries.GetById;
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
    public class StoreController : BaseController
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "StoreStaff")]
        [HttpPost]
        public async Task<IActionResult> CreateStore([FromBody] CreateStoreCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStores([FromQuery] GetAllStoresQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStoreById(Guid id)
        {
            var result = await _mediator.Send(new GetStoreByIdQuery(id));
            return Ok(result);
        }

        [Authorize(Roles = "StoreStaff")]
        [HttpPut]
        public async Task<IActionResult> UpdateStore([FromBody] UpdateStoreCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [Authorize(Roles = "StoreStaff")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(Guid id)
        {
            var result = await _mediator.Send(new DeleteStoreCommand(id));
            return Ok(result);
        }

        [Authorize(Roles = "StoreStaff")]
        [HttpPost("employees")]
        public async Task<IActionResult> CreateStoreEmployee([FromBody] CreateStoreEmployeeCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [Authorize(Roles = "StoreStaff")]
        [HttpGet("employees")]
        public async Task<IActionResult> GetStoreEmployees([FromQuery] GetStoreUserQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [Authorize(Roles = "StoreStaff")]
        [HttpGet("order-items")]
        public async Task<IActionResult> GetShopOrderItems([FromQuery] GetShopOrderItemsCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
