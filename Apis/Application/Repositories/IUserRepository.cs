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
        Task<BaseUser> GetUserByUserNameAndPasswordHash(string email, string passwordHash);

        Task<bool> CheckUserNameExited(string username);
    }
}
