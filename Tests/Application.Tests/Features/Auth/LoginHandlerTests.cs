// using FluentAssertions;
// using Moq;
// using SilverCart.Application.Interfaces;
// using SilverCart.Domain.Entities;
// using Domain.Tests;
// using Infrastructures;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.Data;
// using Infrastructures.Interfaces.System;
// using AutoFixture;

// namespace Application.Tests.Features.Auth
// {
//     public class LoginHandlerTests : SetupTest
//     {
//         private readonly LoginHandler _handler;
//         private readonly Mock<UserManager<BaseUser>> _userManager;
//         private readonly Mock<IJwtTokenGenerator> _jwtTokenGenerator;
//         public LoginHandlerTests()
//         {
//             _userManager = new Mock<UserManager<BaseUser>>();
//             _jwtTokenGenerator = new Mock<IJwtTokenGenerator>();
//             _handler = new LoginHandler(
//                     _userManager.Object,
//                 _jwtTokenGenerator.Object,
//                 _currentTimeMock.Object
//             );
//         }

//         [Fact]
//         public async Task Handle_WithValidCredentials_ShouldReturnToken()
//         {
//             // Arrange
//             var request = new LoginUserCommand("test@example.com", "Test@123")
//             {
//                 Email = "test@example.com",
//                 Password = "Test@123"
//             };

//             var user = _fixture.Build<BaseUser>()
//                 .With(x => x.Email, request.Email)
//                 .With(x => x.PasswordHash, BCrypt.Net.BCrypt.HashPassword(request.Password))
//                 .Create();

//             _userManager.Setup(x => x.FindByEmailAsync(request.Email))
//                 .ReturnsAsync(user);

//             var token = "test_token";
//             _jwtTokenGenerator.Setup(x => x.GenerateJwtToken(user, "Admin"))
//                 .Returns(token);

//             // Act
//             var result = await _handler.Handle(request, CancellationToken.None);

//             // Assert
//             result.Should().NotBeNull();
//             result.AccessToken.Should().Be(token);
//         }

//         [Fact]
//         public async Task Handle_WithInvalidEmail_ShouldReturnError()
//         {
//             // Arrange
//             var request = new LoginUserCommand("invalid@example.com", "Test@123");

//             _userManager.Setup(x => x.FindByEmailAsync(request.Email))
//                 .ReturnsAsync((BaseUser)null);

//             // Act
//             var result = await _handler.Handle(request, CancellationToken.None);

//             // Assert
//             result.Should().BeNull();
//         }

//         [Fact]
//         public async Task Handle_WithInvalidPassword_ShouldReturnError()
//         {
//             // Arrange
//             var request = new LoginUserCommand("test@example.com", "WrongPassword");

//             var user = _fixture.Build<BaseUser>()
//                 .With(x => x.Email, request.Email)
//                 .With(x => x.PasswordHash, BCrypt.Net.BCrypt.HashPassword("Test@123"))
//                 .Create();

//             _userManager.Setup(x => x.FindByEmailAsync(request.Email))
//                 .ReturnsAsync(user);

//             // Act
//             var result = await _handler.Handle(request, CancellationToken.None);

//             // Assert
//             result.Should().BeNull();
//         }
//     }
// } 