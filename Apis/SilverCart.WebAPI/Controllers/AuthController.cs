using Infrastructures;
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

    // private readonly UserManager<BaseUser> _userManager;
    // private readonly SignInManager<BaseUser> _signInManager;
    // private readonly RoleManager<BaseRole> _roleManager;
    // private readonly IAuthService _authService;

    // public AuthController(
    //     UserManager<BaseUser> userManager,
    //     SignInManager<BaseUser> signInManager,
    //     RoleManager<BaseRole> roleManager,
    //     IAuthService authService)
    // {
    //     _userManager = userManager;
    //     _signInManager = signInManager;
    //     _roleManager = roleManager;
    //     _authService = authService;
    // }

    // [HttpPost("register")]
    // public async Task<IActionResult> Register(RegisterUserDTO model)
    // {
    //     var user = new CustomerUser()
    //     {
    //         UserName = model.Email,
    //         Email = model.Email,
    //         FullName = model.FullName
    //     };

    //     var result = await _userManager.CreateAsync(user, model.Password);

    //     if (!result.Succeeded)
    //         return BadRequest(result.Errors);

    //     // Optional: assign default role
    //     await _userManager.AddToRoleAsync(user, "Customer");

    //     return Ok("Registered successfully.");
    // }

    // [HttpPost("login")]
    // public async Task<IActionResult> Login(LoginUserDTO model)
    // {
    //     var result = await _authService.LoginAsync(model);
    //     if (result.IsSuccess)
    //     {
    //         return Ok(result.Value);
    //     }
    //     return BadRequest(result);
    // }
    // [HttpPost("register/store-user")]
    // public async Task<IActionResult> RegisterStore([FromBody] RegisterUserDTO dto)
    // {
    //     var result = await _authService.RegisterStoreUserAsync(dto);
    //     return Ok(result);
    // }
    // [HttpPost("register/customer-user")]
    // public async Task<IActionResult> RegisterCustomer([FromBody] RegisterUserDTO dto)
    // {
    //     var result = await _authService.RegisterCustomerUserAsync(dto);
    //     return Ok(result);
    // }[Http
}