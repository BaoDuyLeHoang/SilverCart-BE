using Application.Interfaces;
using Application.ViewModels.CategorysViewModels;
using AutoFixture;
using Application.Commons;
using Domain.Entities;
using Domain.Tests;
using FluentAssertions;
using Infrastructures.Services;
using Moq;

namespace Application.Tests.Services
{
    public class CategoryServiceTests : SetupTest
    {
        private readonly ICategoryService _categoryService;

        public CategoryServiceTests()
        {
            _categoryService = new CategoryService(_unitOfWorkMock.Object, _mapperConfig);
        }

        [Fact]
        public async Task GetCategoryAsync_ShouldReturnCorrentData()
        {
            //arrange
            var mocks = _fixture.Build<Category>().CreateMany(100).ToList();
            var expectedResult = _mapperConfig.Map<List<CategoryViewModel>>(mocks);

            _unitOfWorkMock.Setup(x => x.CategoryRepository.GetAllAsync()).ReturnsAsync(mocks);

            //act
            var result = await _categoryService.GetCategoryAsync();

            //assert
            _unitOfWorkMock.Verify(x => x.CategoryRepository.GetAllAsync(), Times.Once());
            result.Should().BeEquivalentTo(expectedResult);
        }


        [Fact]
        public async Task CreateCategoryAsync_ShouldReturnCorrentData_WhenSuccessSaved()
        {
            //arrange
            var mocks = _fixture.Build<CreateCategoryViewModel>().Create();

            _unitOfWorkMock.Setup(x => x.CategoryRepository.AddAsync(It.IsAny<Category>()))
                .Returns(Task.CompletedTask);

            _unitOfWorkMock.Setup(x => x.SaveChangeAsync()).ReturnsAsync(1);
            //act
            var result = await _categoryService.CreateCategoryAsync(mocks);

            //assert
            _unitOfWorkMock.Verify(
                x => x.CategoryRepository.AddAsync(It.IsAny<Category>()), Times.Once());

            _unitOfWorkMock.Verify(x => x.SaveChangeAsync(), Times.Once());
        }

        [Fact]
        public async Task CreateCategoryAsync_ShouldReturnNull_WhenFailedSave()
        {
            //arrange
            var mocks = _fixture.Build<CreateCategoryViewModel>().Create();

            _unitOfWorkMock.Setup(
                x => x.CategoryRepository.AddAsync(It.IsAny<Category>())).Returns(Task.CompletedTask);

            _unitOfWorkMock.Setup(x => x.SaveChangeAsync()).ReturnsAsync(0);

            //act
            var result = await _categoryService.CreateCategoryAsync(mocks);

            //assert
            _unitOfWorkMock.Verify(
                x => x.CategoryRepository.AddAsync(It.IsAny<Category>()), Times.Once());

            _unitOfWorkMock.Verify(x => x.SaveChangeAsync(), Times.Once());

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetCategoryPagingsionAsync_ShouldReturnCorrectDataWhenDidNotPassTheParameters()
        {
            //arrange
            var mockData = new Pagination<Category>
            {
                Items = _fixture.Build<Category>().CreateMany(100).ToList(),
                PageIndex = 0,
                PageSize = 100,
                TotalItemsCount = 100
            };
            var expectedResult = _mapperConfig.Map<Pagination<Category>>(mockData);

            _unitOfWorkMock.Setup(x => x.CategoryRepository.ToPagination(0, 10)).ReturnsAsync(mockData);

            //act
            var result = await _categoryService.GetCategoryPagingsionAsync();

            //assert
            _unitOfWorkMock.Verify(x => x.CategoryRepository.ToPagination(0, 10), Times.Once());
        }

        [Fact]
        public async Task GetCategoryAsync_ShouldReturnCorrectData()
        {
            //arrange
            var mocks = _fixture.Build<Category>().CreateMany(100).ToList();
            var expectedResult = _mapperConfig.Map<List<CategoryViewModel>>(mocks);

            _unitOfWorkMock.Setup(x => x.CategoryRepository.GetAllAsync()).ReturnsAsync(mocks);

            //act
            var result = await _categoryService.GetCategoryAsync();

            //assert
            _unitOfWorkMock.Verify(x => x.CategoryRepository.GetAllAsync(), Times.Once());
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
