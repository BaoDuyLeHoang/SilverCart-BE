using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Infrastructures.Commons.Paginations;
using Infrastructures.Features.Users.Queries.GetAllUsers;
using Infrastructures.Features.Users.Queries.GetDependantUser;
using Infrastructures.Features.Users.Queries.GetGuardianUser;
using Infrastructures;
using Microsoft.AspNetCore.Authorization;
using Infrastructures.Features.Users.Queries.GetDetailsUser;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : BaseController
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<PagedResult<GetAllUsersResponse>>> GetAllUsers(
            [FromQuery] GetAllUsersQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("dependent-users")]
        public async
            Task<ActionResult<List<Infrastructures.Features.Users.Queries.GetDependantUser.GetDependentUserResponse>>>
            GetDependentUsers([FromQuery] GetDependentUserQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("update-profile")]
        public async Task<ActionResult<Guid>> UpdateProfile([FromBody] UpdateUserProfileCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("guardian-users")]
        public async Task<ActionResult<List<GetGuardianUserResponse>>> GetGuardianUsers(
            [FromQuery] GetGuardianUserQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GetDetailUserResponse>> GetDetailsUser([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetDetailUserQuery(id));
            return Ok(result);
        }

        [HttpPost("dependent-user")]
        [Authorize(Roles = "Guardian")]
        public async Task<ActionResult<List<Guid>>> CreateDependentUsers([FromBody] CreateDependentUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}