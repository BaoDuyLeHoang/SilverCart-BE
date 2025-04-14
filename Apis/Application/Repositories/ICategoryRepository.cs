using Domain.Entities;

namespace Application.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        List<Category> GetTop3LatestCategory();
    }
}
