// using FluentAssertions;
// using SilverCart.Application.Features.Categories.Queries.GetAll;
// using SilverCart.Domain.Entities.Categories;
// using Domain.Tests;
// using Infrastructures.Features.Categories.Queries.GetAll;

// namespace Application.Tests.Features.Categories
// {
//     public class GetAllCategoriesHandlerTests : SetupTest
//     {
//         private readonly GetAllCategoriesHandler _handler;

//         public GetAllCategoriesHandlerTests()
//         {
//             _handler = new GetAllCategoriesHandler(_unitOfWorkMock.Object);
//         }

//         [Fact]
//         public async Task Handle_ShouldReturnAllCategories()
//         {
//             // Arrange
//             var categories = _fixture.Build<Category>()
//                 .With(x => x.IsDeleted, false)
//                 .CreateMany(5)
//                 .ToList();

//             _unitOfWorkMock.Setup(x => x.Categories.GetAllAsync())
//                 .ReturnsAsync(categories);

//             var request = new GetAllCategoriesRequest();

//             // Act
//             var result = await _handler.Handle(request, CancellationToken.None);

//             // Assert
//             result.IsSuccess.Should().BeTrue();
//             result.Data.Should().HaveCount(5);
//         }

//         [Fact]
//         public async Task Handle_WithNoCategories_ShouldReturnEmptyList()
//         {
//             // Arrange
//             _unitOfWorkMock.Setup(x => x.Categories.GetAllAsync())
//                 .ReturnsAsync(new List<Category>());

//             var request = new GetAllCategoriesRequest();

//             // Act
//             var result = await _handler.Handle(request, CancellationToken.None);

//             // Assert
//             result.IsSuccess.Should().BeTrue();
//             result.Data.Should().BeEmpty();
//         }

//         [Fact]
//         public async Task Handle_WithError_ShouldReturnFailureResult()
//         {
//             // Arrange
//             _unitOfWorkMock.Setup(x => x.Categories.GetAllAsync())
//                 .ThrowsAsync(new Exception("Database error"));

//             var request = new GetAllCategoriesRequest();

//             // Act
//             var result = await _handler.Handle(request, CancellationToken.None);

//             // Assert
//             result.IsSuccess.Should().BeFalse();
//             result.Message.Should().Contain("Lỗi khi lấy danh sách danh mục");
//         }
//     }
// } 