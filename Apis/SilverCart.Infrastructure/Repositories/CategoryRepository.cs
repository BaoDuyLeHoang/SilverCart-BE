using SilverCart.Domain.Entities;
using SilverCart.Application.Interfaces;
using SilverCart.Application.Repositories;

namespace Infrastructures.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetTop3LatestCategory()
        {
            // this is how we create the custom method with repository pattern

            return _dbContext.Categories.Take(3).OrderByDescending(x => x.CreationDate).ToList();
        }
    }
}