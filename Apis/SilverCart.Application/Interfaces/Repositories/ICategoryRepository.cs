using SilverCart.Domain.Entities;

namespace SilverCart.Application.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        List<Category> GetTop3LatestCategory();
    }
}
