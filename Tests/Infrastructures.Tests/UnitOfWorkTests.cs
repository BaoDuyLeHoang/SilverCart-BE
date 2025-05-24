//using SilverCart.Infrastructure;
//using AutoFixture;
//using SilverCart.Domain.Entities;
//using SilverCart.Domain.Tests;
//using FluentAssertions;
//using Moq;

//namespace Infrastructures.Tests
//{
//    public class UnitOfWorkTests : SetupTest
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        public UnitOfWorkTests()
//        {
//            _unitOfWork = new UnitOfWork(
//                _dbContext,
//                _categoryRepositoryMock.Object,
//                _userRepository.Object
//                );
//        }

//        [Fact]
//        public async Task TestUnitOfWork()
//        {
//            // arrange
//            var mockData = _fixture.Build<Category>().CreateMany(10).ToList();

//            _categoryRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(mockData);

//            // act
//            var items = await _unitOfWork.CategoryRepository.GetAllAsync();

//            // assert
//            items.Should().BeEquivalentTo(mockData);
//        }

//    }
//}
