// Infrastructures/Repositories/UserRepository.cs

using Application.Interfaces;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Repositories
{
    public class UserRepository : GenericRepository<BaseUser>, IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                timeService,
                claimsService)
        {
            _dbContext = dbContext;
        }

        public Task<bool> CheckEmailExisted(string email) =>
            _dbContext.Users.AnyAsync(u => u.Email == email);

        public Task<bool> CheckPhoneExisted(string phone) =>
                    _dbContext.Users.AnyAsync(u => u.Phone == phone);

        public async Task<BaseUser?> GetUserByEmail(string email)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<BaseUser> GetUserByRefreshToken(string refreshToken)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        }

        public async Task<BaseUser> GetAdminUserByEmail(string username)
        {
            return await _dbContext.Set<AdministratorUser>()
                .FirstOrDefaultAsync(u => u.Email == username);
        }

        public async Task<BaseUser?> GetUserByPhone(string phoneNumber)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Phone == phoneNumber);
        }
    }
}