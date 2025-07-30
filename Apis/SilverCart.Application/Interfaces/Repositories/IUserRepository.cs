using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructures.Commons.Paginations;
using AutoMapper;
using SilverCart.Domain.Enums;

namespace Infrastructures.Interfaces.Repositories;

public interface IUserRepository : IGenericRepository<BaseUser>
{
    /// <summary>
    /// Lọc người dùng dựa trên từ khóa và vai trò
    /// </summary>
    /// <param name="keyword">Từ khóa tìm kiếm (email, tên, số điện thoại)</param>
    /// <param name="roles">Danh sách vai trò cần lọc</param>
    /// <returns>Danh sách người dùng phù hợp với điều kiện</returns>
    Task<IQueryable<BaseUser>> FilterUsersAsync(string? keyword = null, RoleEnum[]? roles = null, RoleEnum? currentRole = null);

    /// <summary>
    /// Lọc người dùng dựa trên từ khóa và vai trò với phân trang
    /// </summary>
    /// <param name="keyword">Từ khóa tìm kiếm</param>
    /// <param name="roles">Danh sách vai trò</param>
    /// <param name="pageNumber">Số trang</param>
    /// <param name="pageSize">Số lượng mỗi trang</param>
    /// <returns>Kết quả phân trang chứa danh sách người dùng</returns>
    Task<PagedResult<BaseUser>> FilterUsersWithPaginationAsync(
        string? keyword = null,
        RoleEnum[]? roles = null,
        int pageNumber = 1,
        int pageSize = 10,
        RoleEnum? currentRole = null);
}
