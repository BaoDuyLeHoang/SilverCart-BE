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

        public Task<bool> CheckUserNameExited(string username) => 
            _dbContext.Users.AnyAsync(u => u.Email == username);

        public async Task<BaseUser> GetUserByUserNameAndPasswordHash(string email, string passwordHash)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(record => record.Email == email
                                               && record.PasswordHash == passwordHash);
            if(user is null)
            {
                throw new Exception("Email or password is not correct");
            }

            return user;
        }
        
        public async Task<BaseUser> GetUserByEmail(string email)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
        
        public async Task<BaseUser> GetUserByRefreshToken(string refreshToken)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        }
        
        public async Task<BaseUser> GetAdminUserByUsername(string username)
        {
            return await _dbContext.Set<AdministratorUser>()
                .FirstOrDefaultAsync(u => u.Email == username);
        }
    }
}