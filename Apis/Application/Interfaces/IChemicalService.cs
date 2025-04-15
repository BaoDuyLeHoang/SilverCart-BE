using Application.Commons;
using Application.ViewModels.CategorysViewModels;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<CategoryViewModel>> GetCategoryAsync();
        public Task<CategoryViewModel?> CreateCategoryAsync(CreateCategoryViewModel category);
        public Task<Pagination<CategoryViewModel>> GetCategoryPagingsionAsync(int pageIndex = 0, int pageSize = 10);
    }
}
