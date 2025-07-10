using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Application.Commons;
using Application.Interfaces;
using Application.Utils;
using Application.ViewModels.UserViewModels;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHostingEnvironment _hostingEnvironment;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper, IHostingEnvironment hostingEnvironment)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _hostingEnvironment = hostingEnvironment;
    }

    public async Task<Result<Pagination<BaseUser>>> GetUsers(UserFilterDTO filter, int pageIndex, int pageSize)
    {
        var query = await _unitOfWork.UserRepository.GetAllAsync();
        var totalCount = await query.CountAsync();
        var filterExpressions = new List<Expression<Func<BaseUser, bool>>>();

        if (filter.IsVerified.HasValue)
        {
            filterExpressions.Add(x => x.IsVerified == filter.IsVerified.Value);
        }

        if (filter.SignInDateFrom.HasValue)
        {
            filterExpressions.Add(x => x.SignInTime >= filter.SignInDateFrom.Value);
        }

        if (filter.SignInDateTo.HasValue)
        {
            filterExpressions.Add(x => x.SignInTime <= filter.SignInDateTo.Value);
        }

        if (filter.CreatedDateFrom.HasValue)
        {
            filterExpressions.Add(x => x.CreationDate >= filter.CreatedDateFrom.Value);
        }

        if (filter.CreatedDateTo.HasValue)
        {
            filterExpressions.Add(x => x.CreationDate <= filter.CreatedDateTo.Value);
        }

        if (!string.IsNullOrEmpty(filter.SearchTerm))
        {
            filterExpressions.Add(x => x.Email.Contains(filter.SearchTerm));
        }

        // Combine the base query and filter expressions
        var finalQuery = query;
        foreach (var filterExpression in filterExpressions)
        {
            finalQuery = finalQuery.Where(filterExpression);
        }

        // Apply sorting, paging, and execute the query
        var items = await finalQuery
            .OrderByDescending(x => x.CreationDate)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return Result<Pagination<BaseUser>>.Success(new Pagination<BaseUser>
        {
            Items = items,
            TotalItemsCount = totalCount,
            PageIndex = pageIndex,
            PageSize = pageSize
        });
    }

    public Task<Result<BaseUser>> GetUserById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<BaseUser>> CreateUser(RegisterUserDTO model)
    {
        throw new NotImplementedException();
    }

    public Task<Result<BaseUser>> UpdateUser(UpdateUserDTO model)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> ChangePassword(ChangePasswordDTO model)
    {
        throw new NotImplementedException();
    }
}