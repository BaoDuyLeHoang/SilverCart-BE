using AutoFixture;
using Domain.Entities;
using Domain.Tests;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Tests
{
    public class AppDbContextTests : SetupTest, IDisposable
    {
        [Fact]
        public async Task AppDbContext_CategorysDbSetShouldReturnCorrectData()
        {

            var mockData = _fixture.Build<Category>().CreateMany(10).ToList();
            await _dbContext.Categorys.AddRangeAsync(mockData);
            
            await _dbContext.SaveChangesAsync();

            var result = await _dbContext.Categorys.ToListAsync();
            result.Should().BeEquivalentTo(mockData);
        }

        [Fact]
        public async Task AppDbContext_CategorysDbSetShouldReturnEmptyListWhenNotHavingData()
        {
            var result = await _dbContext.Categorys.ToListAsync();
            result.Should().BeEmpty();
        }
    }
}
