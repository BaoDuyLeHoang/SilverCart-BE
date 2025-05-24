using AutoFixture;
using SilverCart.Domain.Entities;
using FluentAssertions;
using Domain.Tests;

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
            //var result = _mapperConfig.Map<CategoryViewModel>(categoryMock);

            //assert
            //result._Id.Should().Be(categoryMock.Id.ToString());
        }
    }
}
