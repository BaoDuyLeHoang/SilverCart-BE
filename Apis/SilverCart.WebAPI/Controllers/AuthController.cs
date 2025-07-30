using Infrastructures;
using Infrastructures.Commons;
using Infrastructures.Features.Auth.GenerateQrLoginToken;
using Infrastructures.Features.Auth.GenerateTokenBaseOnDependentId;
using Infrastructures.Features.Auth.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [Authorize(Roles = "Guardian")]
    [HttpPost("register/dependent-user")]
    public async Task<ActionResult<Guid>> RegisterDependentUser(
        [FromBody] CreateDependentUserCommand command
    )
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginUserResponse>> Login([FromBody] LoginUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<ActionResult<Guid>> Register([FromBody] RegisterUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("change-password")]
    public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("generate-qr-login-token")]
    public async Task<ActionResult<string>> GenerateQrLoginToken([FromQuery] Guid dependentUserId)
    {
        var result = await _mediator.Send(new GenerateQrLoginTokenCommand(dependentUserId));
        return Ok(result);
    }

    [HttpGet("elder-login")]
    public async Task<ActionResult<ElderLoginResponse>> ElderLogin([FromQuery] string token)
    {
        var result = await _mediator.Send(new ElderLoginCommand(token));
        return Ok(result);
    }

    [HttpGet("generate-token-base-on-dependentId")]
    public async Task<ActionResult<string>> GenerateTokenBaseOnDependentId(
        [FromQuery] GenerateTokenBaseOnDependentIdCommand command
    )
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("forgot-password")]
    public async Task<ActionResult<string>> ForgotPassword([FromBody] ForgotPasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("verify-reset-token")]
    public async Task<ActionResult<bool>> VerifyResetToken([FromBody] VerifyResetTokenCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("reset-password")]
    public async Task<ActionResult<bool>> ResetPassword([FromBody] ResetPasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
