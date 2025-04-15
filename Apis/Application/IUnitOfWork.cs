using Application.Repositories;

namespace Application
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }

        public IUserRepository UserRepository { get; }

        public Task<int> SaveChangeAsync();
    }
}
