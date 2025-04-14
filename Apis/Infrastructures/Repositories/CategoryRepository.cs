using Application.Interfaces;
using Application.Repositories;
using Domain.Entities;

namespace Infrastructures.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext,
            ICurrentTime timeService,
            IClaimsService claimsService)
            : base(dbContext,
                  timeService,
                  claimsService)
        {
            _dbContext = dbContext;
        }

        public List<Category> GetTop3LatestCategory()
        {
            // this is how we create the custom method with repository pattern

            return _dbContext.Categorys.Take(3).OrderByDescending(x => x.CreationDate).ToList();
        }
    }
}
