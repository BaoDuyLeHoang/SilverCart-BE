using Application.Commons;
using Application.Interfaces;
using Application.Services;
using Application.ViewModels.UserViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public partial class UserController : BaseController
{
    private readonly IUserService _userService;
    private readonly IEmailService _emailService;

    public UserController(IUserService userService, IEmailService emailService)
    {
        _userService = userService;
        _emailService = emailService;
    }


    [Authorize(Roles = "SuperAdmin,Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAllCustomerUsers([FromQuery] UserFilterDTO filter,
        int pageIndex,
        int pageSize)
    {
        if (pageIndex < 1 || pageSize < 1)
            return BadRequest("Page index and page size must be greater than 0");
        filter ??= new();
        filter.UserType = UserType.Customer;
        var result = await _userService.GetUsers(filter, pageIndex, pageSize);
        return result.ToObjectResult();
    }

    [Authorize(Roles = "SuperAdmin,Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAllStoreUsers([FromQuery] UserFilterDTO filter,
        int pageIndex,
        int pageSize)
    {
        if (pageIndex < 1 || pageSize < 1)
            return BadRequest("Page index and page size must be greater than 0");
        filter ??= new();
        filter.UserType = UserType.Customer;
        var result = await _userService.GetUsers(filter, pageIndex, pageSize);
        return result.ToObjectResult();
    }

    [Authorize(Roles = "SuperAdmin,Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAllAdministatorUsers(
        [FromQuery] UserFilterDTO filter, int pageIndex,
        int pageSize)
    {
        if (pageIndex < 1 || pageSize < 1)
            return BadRequest("Page index and page size must be greater than 0");
        filter ??= new();
        filter.UserType = UserType.Customer;
        var result = await _userService.GetUsers(filter, pageIndex, pageSize);
        return result.ToObjectResult();
    }

    [Authorize(Roles = "SuperAdmin,Admin")]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers([FromQuery] UserFilterDTO filter, int pageIndex,
        int pageSize)
    {
        if (pageIndex < 1 || pageSize < 1)
            return BadRequest("Page index and page size must be greater than 0");
        var result = await _userService.GetUsers(filter, pageIndex, pageSize);
        return result.ToObjectResult();
    }
}