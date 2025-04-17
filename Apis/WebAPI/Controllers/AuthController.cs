using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost()]
        public async Task<IActionResult> RegisterAsync(UserLoginDTO loginObject)
        {
            await _userService.RegisterAsync(loginObject);
            return Ok(new { message = "Registration successful. Please check your email to verify your account." });
        }

        [HttpPost()]
        public async Task<IActionResult> VerifyEmailAsync([FromQuery] string token, [FromQuery] string email)
        {
            var result = await _userService.VerifyEmailAsync(token, email);
            return Ok(new { message = result });
        }

        [HttpPost()]
        public async Task<IActionResult> LoginAsync(UserLoginDTO loginObject)
        {
            var result = await _userService.LoginAsync(loginObject);
            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDTO refreshTokenDto)
        {
            var result = await _userService.RefreshTokenAsync(refreshTokenDto.RefreshToken);
            return Ok(result);
        }

        [HttpPost()]
        [Authorize]
        public async Task<IActionResult> RevokeToken([FromBody] RefreshTokenDTO refreshTokenDto)
        {
            await _userService.RevokeTokenAsync(refreshTokenDto.RefreshToken);
            return Ok(new { message = "Token revoked successfully" });
        }

        [HttpPost("/auth/admin/create-user")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreateUser([FromBody] UserRegisterDTO userRegisterDTO, [FromQuery] int roleId)
        {
            var result = await _userService.CreateUser(userRegisterDTO, roleId);
            if (result == null)
            {
                return BadRequest("User creation failed");
            }

            return Ok(result);
        }

        [HttpPost("/auth/admin/login")]
        public async Task<IActionResult> LoginSuperAdmin([FromBody] UserLoginDTO loginObject)
        {
            var result = await _userService.LoginSuperAdmin(loginObject);
            return Ok(result);
        }
    }
}