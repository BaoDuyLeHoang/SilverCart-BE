// using FluentAssertions;
// using SilverCart.Application.Features.Orders.Commands.Create;
// using SilverCart.Domain.Entities.Orders;
// using SilverCart.Domain.Enums;
// using Domain.Tests;
// using Infrastructures.Features.Orders.Commands.Create;

// namespace Application.Tests.Features.Orders
// {
//     public class CreateOrderHandlerTests : SetupTest
//     {
//         private readonly CreateOrderHandler _handler;

//         public CreateOrderHandlerTests()
//         {
//             _handler = new CreateOrderHandler(
//                 _unitOfWorkMock.Object,
//                 _mapperConfig,
//                 _currentTimeMock.Object,
//                 _claimsServiceMock.Object
//             );
//         }

//         [Fact]
//         public async Task Handle_WithValidRequest_ShouldCreateOrder()
//         {
//             // Arrange
//             var userId = Guid.NewGuid();
//             _claimsServiceMock.Setup(x => x.CurrentUserId).Returns(userId);

//             var request = new CreateOrderRequest
//             {
//                 ShippingAddress = "123 Test St",
//                 PaymentMethod = PaymentMethodEnum.COD,
//                 Items = new List<OrderItemRequest>
//                 {
//                     new() { ProductId = Guid.NewGuid(), Quantity = 2 },
//                     new() { ProductId = Guid.NewGuid(), Quantity = 1 }
//                 }
//             };

//             var order = _fixture.Build<Order>()
//                 .With(x => x.UserId, userId)
//                 .With(x => x.Status, OrderStatusEnum.Pending)
//                 .Create();

//             _unitOfWorkMock.Setup(x => x.Orders.AddAsync(It.IsAny<Order>()))
//                 .ReturnsAsync(order);

//             // Act
//             var result = await _handler.Handle(request, CancellationToken.None);

//             // Assert
//             result.IsSuccess.Should().BeTrue();
//             result.Data.Should().NotBeNull();
//             result.Data.Status.Should().Be(OrderStatusEnum.Pending);
//         }

//         [Fact]
//         public async Task Handle_WithInvalidItems_ShouldReturnError()
//         {
//             // Arrange
//             var request = new CreateOrderRequest
//             {
//                 ShippingAddress = "123 Test St",
//                 PaymentMethod = PaymentMethodEnum.COD,
//                 Items = new List<OrderItemRequest>() // Empty items
//             };

//             // Act
//             var result = await _handler.Handle(request, CancellationToken.None);

//             // Assert
//             result.IsSuccess.Should().BeFalse();
//             result.Message.Should().Contain("Đơn hàng phải có ít nhất một sản phẩm");
//         }

//         [Fact]
//         public async Task Handle_WithDatabaseError_ShouldReturnError()
//         {
//             // Arrange
//             var request = new CreateOrderRequest
//             {
//                 ShippingAddress = "123 Test St",
//                 PaymentMethod = PaymentMethodEnum.COD,
//                 Items = new List<OrderItemRequest>
//                 {
//                     new() { ProductId = Guid.NewGuid(), Quantity = 1 }
//                 }
//             };

//             _unitOfWorkMock.Setup(x => x.Orders.AddAsync(It.IsAny<Order>()))
//                 .ThrowsAsync(new Exception("Database error"));

//             // Act
//             var result = await _handler.Handle(request, CancellationToken.None);

//             // Assert
//             result.IsSuccess.Should().BeFalse();
//             result.Message.Should().Contain("Lỗi khi tạo đơn hàng");
//         }
//     }
// } 