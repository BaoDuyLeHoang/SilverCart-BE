using Application;
using Application.Repositories;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(AppDbContext dbContext,
            ICategoryRepository categoryRepository,
            IUserRepository userRepository)
        {
            _dbContext = dbContext;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }
        public ICategoryRepository CategoryRepository => _categoryRepository;

        public IUserRepository UserRepository => _userRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
