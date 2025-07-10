// Application/Interfaces/IUserService.cs

using Application.Commons;
using Application.ViewModels.UserViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<Result<Pagination<BaseUser>>> GetUsers(UserFilterDTO filter, int pageIndex, int pageSize);
    }
}