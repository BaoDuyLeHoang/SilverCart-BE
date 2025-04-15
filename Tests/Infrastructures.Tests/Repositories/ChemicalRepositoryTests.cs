using Application.Repositories;
using AutoFixture;
using Domain.Entities;
using Domain.Tests;
using FluentAssertions;
using Infrastructures.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Tests.Repositories
{
    public class CategoryRepositoryTests : SetupTest
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryRepositoryTests()
        {
            _categoryRepository = new CategoryRepository(
                _dbContext,
                _currentTimeMock.Object,
                _claimsServiceMock.Object);
        }

        [Fact]
        public async Task CategoryRepository_Should_ReturnCorrectData()
        {
            // arrange
            var mockData = _fixture.Build<Category>().CreateMany(10).ToList();
            await _dbContext.Categorys.AddRangeAsync(mockData);
            await _dbContext.SaveChangesAsync();

            // act
            var result = await _categoryRepository.GetAllAsync();

            // assert
            result.Should().BeEquivalentTo(mockData);
        }
    }
}
