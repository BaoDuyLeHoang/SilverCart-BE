using Infrastructures.Interfaces.Entities;
using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities.Auth;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Infrastructures.Commons.Paginations;
using SilverCart.Domain.Enums;

namespace Infrastructures.Repositories
{
    public class UserRepository : GenericRepository<BaseUser>, IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<BaseUser> _userManager;

        public UserRepository(AppDbContext context, UserManager<BaseUser> userManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
        }

        private static bool CanViewRole(RoleEnum? viewer, RoleEnum target)
        {
            return viewer switch
            {
                RoleEnum.SuperAdmin => true,
                RoleEnum.Admin => target != RoleEnum.SuperAdmin,
                RoleEnum.ShopOwner => target == RoleEnum.Staff || target == RoleEnum.Consultant,
                RoleEnum.Guardian => target == RoleEnum.DependentUser,
                _ => false
            };
        }
        public async Task<IQueryable<BaseUser>> FilterUsersAsync(string? keyword = null, RoleEnum[]? roles = null, RoleEnum? currentRole = null)
        {
            // Get base query with user roles included
            var query = _context.Users
                .Include(u => u.Addresses)
                .AsQueryable();

            // Apply keyword filter if provided
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower().Trim();
                query = query.Where(u =>
                    (u.Email != null && u.Email.ToLower().Contains(keyword)) ||
                    (u.FullName != null && u.FullName.ToLower().Contains(keyword)) ||
                    (u.PhoneNumber != null && u.PhoneNumber.ToLower().Contains(keyword))
                );
            }
            // Apply role filter if provided
            if (roles != null && roles.Length > 0)
            {
                // Get user IDs for the specified roles
                var userIds = new HashSet<Guid>();
                foreach (var role in roles)
                {
                    if (!CanViewRole(currentRole, role))
                    {
                        continue;
                    }
                    var usersInRole = await _userManager.GetUsersInRoleAsync(role.ToString());
                    foreach (var user in usersInRole)
                    {
                        userIds.Add(user.Id);
                    }
                }
                // Filter users by the collected IDs
                query = query.Where(u => userIds.Contains(u.Id));
            }

            // Apply soft delete filter
            query = query.Where(u => !u.IsDeleted);

            return query;
        }

        public async Task<PagedResult<BaseUser>> FilterUsersWithPaginationAsync(
            string? keyword = null,
            RoleEnum[]? roles = null,
            int pageNumber = 1,
            int pageSize = 10,
            RoleEnum? currentRole = null)
        {
            var query = await FilterUsersAsync(keyword, roles, currentRole);

            // Get total count before pagination
            var totalCount = await query.CountAsync();

            // Apply pagination and execute query
            var users = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<BaseUser>
            {
                Results = users,
                TotalNumberOfRecords = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

        }
    }
}