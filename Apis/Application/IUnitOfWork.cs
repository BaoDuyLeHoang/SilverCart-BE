using Application.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }

        public IUserRepository UserRepository { get; }

        public Task<IDbContextTransaction> BeginTransactionAsync();
        public Task<int> SaveChangeAsync();
    }
}
