using Application.Commons;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Application.ViewModels.UserViewModels;
using Infrastructures.Swaggers.Examples;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Swashbuckle.AspNetCore.Filters;

namespace WebAPI.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly AppConfiguration _configuration;

        public AuthController(IAuthService authService, AppConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost()]
        public async Task<IActionResult> RegisterAsync(RegisterUserDTO @object)
        {
            var result = await _authService.RegisterAsync(@object);
            if (_configuration.IsDevelopment)
            {
                return result.ToObjectResult();
            }

            return result.IsSuccess
                ? Ok("Registration successful. Please check your email to verify your account.")
                : result.ToObjectResult();
        }

        [HttpPost()]
        public async Task<IActionResult> VerifyOTPAsync([FromQuery] string otp, [FromQuery] string phoneNumber)
        {
            var result = await _authService.VerifyOTPAsync(otp, phoneNumber);
            return result.ToObjectResult();
        }

        [HttpPost()]
        public async Task<IActionResult> VerifyEmailAsync([FromQuery] string token, [FromQuery] string email)
        {
            var result = await _authService.VerifyEmailAsync(token, email);
            return result.ToObjectResult();
        }

        [HttpPost()]
        public async Task<IActionResult> LoginAsync(LoginUserDTO @object)
        {
            var result = await _authService.LoginAsync(@object);
            return result.IsSuccess
                ? Ok(result)
                : result.ToObjectResult();
        }

        [HttpPost()]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDTO refreshTokenDto)
        {
            var result = await _authService.RefreshTokenAsync(refreshTokenDto.RefreshToken);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RevokeToken([FromBody] RefreshTokenDTO refreshTokenDto)
        {
            var result = await _authService.RevokeTokenAsync(refreshTokenDto.RefreshToken);
            if (result.IsFailure)
            {
                return result.ToObjectResult();
            }

            return Ok("Token revoked successfully");
        }

        [HttpPost("/auth/admin/create-user")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreateUser([FromBody] RegisterUserDTO registerUserDTO, [FromQuery] int roleId)
        {
            var result = await _authService.CreateUser(registerUserDTO, roleId);
            if (result == null)
            {
                return BadRequest("User creation failed");
            }

            return Ok(result);
        }

        [HttpPost("/auth/admin/login")]
        [SwaggerRequestExample(typeof(LoginUserDTO), typeof(LoginRequestSuperAdminExample))]
        public async Task<IActionResult> LoginAdmin([FromBody] LoginUserDTO @object)
        {
            var result = await _authService.LoginSuperAdmin(@object);
            return Ok(result);
        }
    }
}