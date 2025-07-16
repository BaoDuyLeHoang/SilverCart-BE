using SilverCart.Domain.Entities.Categories;

namespace SilverCart.Application.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        List<Category> GetTop3LatestCategory();
    }
}
