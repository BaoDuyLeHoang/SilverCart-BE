﻿using SilverCart.Application.Interfaces;
using SilverCart.Application.Services;
using FluentAssertions;
using Domain.Tests;

namespace Application.Tests.Services
{
    public class CurrentTimeTests : SetupTest
    {
        private readonly ICurrentTime _currentTime;

        public CurrentTimeTests()
        {
            _currentTime = new CurrentTime();
        }

        [Fact]
        public void GetCurrentTime_ShouldReturnTimeExaclyToTheMiliSec()
        {
            //arrange
            var expectedTime = DateTime.UtcNow;

            //act
            var result = _currentTime.GetCurrentTime();

            //assert
            TimeSpan difference = result - expectedTime;
            var timeDiffLessThan1MiliSec = difference < TimeSpan.FromMilliseconds(1);
            timeDiffLessThan1MiliSec.Should().BeTrue();
        }

    }
}
