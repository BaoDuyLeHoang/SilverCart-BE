using Application.Interfaces;
using Application.ViewModels.CategorysViewModels;
using Application.Commons;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<Pagination<CategoryViewModel>> GetCategoryPagingsion(int pageIndex = 0, int pageSize = 10)
        {
            return await _categoryService.GetCategoryPagingsionAsync(pageIndex, pageSize);
        }

        [HttpPost]
        public async Task<CategoryViewModel?> CreateCategory(CreateCategoryViewModel category)
        {
            return await _categoryService.CreateCategoryAsync(category);
        }
    }
}