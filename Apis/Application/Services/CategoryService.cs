using Application;
using Application.Commons;
using Application.Interfaces;
using Application.ViewModels.CategorysViewModels;
using Application.ViewModels.CategorysViewModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoryViewModel>> GetCategoryAsync()
        {
            var categorys = await _unitOfWork.CategoryRepository.GetAllAsync();
            var result = _mapper.Map<List<CategoryViewModel>>(categorys);
            return result;
        }

        public async Task<CategoryViewModel?> CreateCategoryAsync(CreateCategoryViewModel category)
        {
            var categoryObj = _mapper.Map<Category>(category);
            await _unitOfWork.CategoryRepository.AddAsync(categoryObj);
            var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
            if (isSuccess)
            {
                return _mapper.Map<CategoryViewModel>(categoryObj);
            }

            return null;
        }

        public async Task<Pagination<CategoryViewModel>> GetCategoryPagingsionAsync(int pageIndex = 0,
            int pageSize = 10)
        {
            var categorys = await _unitOfWork.CategoryRepository.ToPagination(pageIndex, pageSize);
            var result = _mapper.Map<Pagination<CategoryViewModel>>(categorys);
            return result;
        }
    }
}