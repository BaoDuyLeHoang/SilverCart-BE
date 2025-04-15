using Application.ViewModels.CategorysViewModels;
using AutoFixture;
using Domain.Entities;
using Domain.Tests;
using FluentAssertions;

namespace Infrastructures.Tests.Mappers
{
    public class MapperConfigurasionTests : SetupTest
    {
        [Fact]
        public void TestMapper()
        {
            //arrange
            var categoryMock = _fixture.Build<Category>().Create();

            //act
            var result = _mapperConfig.Map<CategoryViewModel>(categoryMock);

            //assert
            result._Id.Should().Be(categoryMock.Id.ToString());
        }
    }
}
