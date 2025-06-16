//using SilverCart.Infrastructure.ViewModels.CategorysViewModels;
//using AutoFixture;
//using SilverCart.Infrastructure.Commons;
//using SilverCart.Domain.Tests;
//using FluentAssertions;
//using Moq;
//using WebAPI.Controllers;

//namespace WebAPI.Tests.Controllers
//{
//    public class CategoryControllerTests : SetupTest
//    {
//        private readonly CategoryController _categoryController;
//        public CategoryControllerTests()
//        {
//            _categoryController = new CategoryController(_categoryServiceMock.Object);
//        }

//        [Fact]
//        public async Task GetCategoryPagingsion_ShouldReturnCorrectDataWithDefaultParametor()
//        {
//            var mocks = _fixture.Build<Pagination<CategoryViewModel>>().Create();
//            // arrange
//            _categoryServiceMock.Setup(
//                x => x.GetCategoryPagingsionAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(mocks);

//            // act
//            var result = await _categoryController.GetCategoryPagingsion();

//            // assert
//            _categoryServiceMock.Verify(
//                x => x.GetCategoryPagingsionAsync(
//                    It.Is<int>(x => x.Equals(0)),
//                    It.Is<int>(x => x.Equals(10))), Times.Once());

//            result.Should().BeEquivalentTo(mocks);
//        }

//        [Fact]
//        public async Task GetCategoryPagingsion_ShouldReturnCorrectDataWithParametor()
//        {
//            var mocks = _fixture.Build<Pagination<CategoryViewModel>>().Create();
//            // arrange
//            _categoryServiceMock.Setup(
//                x => x.GetCategoryPagingsionAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(mocks);

//            // act
//            var result = await _categoryController.GetCategoryPagingsion(1, 100);

//            // assert
//            _categoryServiceMock.Verify(
//                x => x.GetCategoryPagingsionAsync(
//                    It.Is<int>(x => x.Equals(1)),
//                    It.Is<int>(x => x.Equals(100))), Times.Once());

//            result.Should().BeEquivalentTo(mocks);
//        }

//        [Fact]
//        public async Task CreateCategory_ShouldReturnCorrectData()
//        {
//            var mockModelRequest = _fixture.Build<CreateCategoryViewModel>().Create();
//            var mockModelResponse = _fixture.Build<CategoryViewModel>().Create();
//            // arrange
//            _categoryServiceMock.Setup(
//                x => x.CreateCategoryAsync(It.IsAny<CreateCategoryViewModel>()))
//                        .ReturnsAsync(mockModelResponse);

//            // act
//            var result = await _categoryController.CreateCategory(mockModelRequest);

//            // assert
//            _categoryServiceMock.Verify(
//                x => x.CreateCategoryAsync(It.Is<CreateCategoryViewModel>(
//                    x => x.Equals(mockModelRequest))), Times.Once());

//            result.Should().BeEquivalentTo(mockModelResponse);
//        }
//    }
//}
