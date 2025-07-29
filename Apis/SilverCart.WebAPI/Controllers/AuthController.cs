using Infrastructures;
using Infrastructures.Commons;
using Infrastructures.Features.Auth.GenerateQrLoginToken;
using Infrastructures.Features.Auth.GenerateTokenBaseOnDependentId;
using Infrastructures.Features.Auth.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [Authorize(Roles = "Guardian")]
    [HttpPost("register/dependent-user")]
    [SwaggerResponse(StatusCodes.Status200OK, "Đăng ký người phụ thuộc thành công")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
    [SwaggerResponse(StatusCodes.Status401Unauthorized, "Không có quyền truy cập")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
    public async Task<IActionResult> RegisterDependentUser(
        [FromBody] CreateDependentUserCommand command
    )
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("login")]
    [SwaggerResponse(StatusCodes.Status200OK, "Đăng nhập thành công", typeof(LoginUserResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Thông tin đăng nhập không chính xác")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("register")]
    [SwaggerResponse(StatusCodes.Status200OK, "Đăng ký thành công")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    [SwaggerResponse(StatusCodes.Status200OK, "Làm mới token thành công", typeof(LoginUserResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Token không hợp lệ")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("change-password")]
    [SwaggerResponse(StatusCodes.Status200OK, "Đổi mật khẩu thành công")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Mật khẩu không hợp lệ")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("generate-qr-login-token")]
    [SwaggerResponse(StatusCodes.Status200OK, "Tạo token QR thành công", typeof(string))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy người dùng")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
    public async Task<IActionResult> GenerateQrLoginToken([FromQuery] Guid dependentUserId)
    {
        var result = await _mediator.Send(new GenerateQrLoginTokenCommand(dependentUserId));
        return Ok(result);
    }

    [HttpGet("elder-login")]
    [SwaggerResponse(StatusCodes.Status200OK, "Đăng nhập người cao tuổi thành công", typeof(ElderLoginResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Token không hợp lệ")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy người dùng")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
    public async Task<IActionResult> ElderLogin([FromQuery] string token)
    {
        var result = await _mediator.Send(new ElderLoginCommand(token));
        return Ok(result);
    }

    [HttpGet("generate-token-base-on-dependentId")]
    [SwaggerResponse(StatusCodes.Status200OK, "Tạo token thành công", typeof(string))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy người dùng")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
    public async Task<IActionResult> GenerateTokenBaseOnDependentId(
        [FromQuery] GenerateTokenBaseOnDependentIdCommand command
    )
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("forgot-password")]
    [SwaggerResponse(StatusCodes.Status200OK, "Gửi yêu cầu quên mật khẩu thành công")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy người dùng")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("verify-reset-token")]
    [SwaggerResponse(StatusCodes.Status200OK, "Xác thực token đặt lại mật khẩu thành công")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Token không hợp lệ")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
    public async Task<IActionResult> VerifyResetToken([FromBody] VerifyResetTokenCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("reset-password")]
    [SwaggerResponse(StatusCodes.Status200OK, "Đặt lại mật khẩu thành công")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Dữ liệu không hợp lệ")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Không tìm thấy người dùng")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Lỗi hệ thống")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
