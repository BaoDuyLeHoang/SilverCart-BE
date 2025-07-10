using Infrastructures;
using Infrastructures.Features.Auth.GenerateQrLoginToken;
using Infrastructures.Features.Auth.GenerateTokenBaseOnDependentId;
using Infrastructures.Features.Auth.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Commons.Entities;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Enums;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    [Authorize(Roles = "Guardian")]
    [HttpPost("register/dependent-user")]
    public async Task<IActionResult> RegisterDependentUser([FromBody] CreateDependentUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpGet("generate-qr-login-token")]
    public async Task<IActionResult> GenerateQrLoginToken([FromQuery] Guid dependentUserId)
    {
        var result = await _mediator.Send(new GenerateQrLoginTokenCommand(dependentUserId));
        return Ok(result);
    }
    [HttpGet("elder-login")]
    public async Task<IActionResult> ElderLogin([FromQuery] string token)
    {
        var result = await _mediator.Send(new ElderLoginCommand(token));
        return Ok(result);
    }
    [HttpGet("generate-token-base-on-dependentId")]
    public async Task<IActionResult> GenerateTokenBaseOnDependentId([FromQuery] GenerateTokenBaseOnDependentIdCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}