using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures;
using Infrastructures.Features.Users.Queries.GetAllUsers;
using Infrastructures.Features.Users.Queries.GetDependantUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : BaseController
    {
        private readonly IMediator _mediator = mediator;
        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("dependent-users")]
        public async Task<IActionResult> GetDependentUsers([FromQuery] GetDependentUserQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("update-profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserProfileCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("guardian-users")]
        public async Task<IActionResult> GetGuardianUsers([FromQuery] GetGuardianUserQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

    }
}