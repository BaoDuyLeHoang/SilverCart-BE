using Domain.Entities;

namespace Application.Repositories
{
    public interface IUserRepository : IGenericRepository<BaseUser>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        Task<bool> CheckEmailExisted(string email);
        Task<bool> CheckPhoneExisted(string? phone);
        Task<BaseUser> GetUserByRefreshToken(string refreshToken);
        Task<BaseUser?> GetUserByEmail(string email);
        Task<BaseUser> GetAdminUserByEmail(string superAdminUsername);
        Task<BaseUser?> GetUserByPhone(string phoneNumber);

    }
}
