using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures;
using Infrastructures.Features.Stores.Commands.Create.CreateStore;
using Infrastructures.Features.Stores.Commands.Update.UpdateStore;
using Infrastructures.Features.Stores.Queries.GetMyStore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        // [Authorize(Roles = "Admin")]
        // [HttpPost]
        // public async Task<ActionResult<Guid>> CreateStore([FromBody] CreateStoreCommand command)
        // {
        //     var result = await _mediator.Send(command);
        //     return Ok(result);
        // }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateStore([FromBody] UpdateStoreCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("my-store")]
        public async Task<ActionResult<GetMyStoreQueryResponse>> GetMyStore()
        {
            var result = await _mediator.Send(new GetMyStoreQueryCommand());
            return Ok(result);
        }
    }
}
