using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Orders.Commands.Update.UpdateOrderDetail
{
    public record UpdateOrderDetailsCommand(Guid OrderId, List<UpdateOrderDetailItemCommand> OrderDetails) : IRequest<Guid>;
    public record UpdateOrderDetailItemCommand(Guid OrderDetailId, int Quantity, string? Notes = null);
    public class UpdateOrderDetailsHandler(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<UpdateOrderDetailsCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IClaimsService _claimsService = claimsService;
        public async Task<Guid> Handle(UpdateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _claimsService.CurrentUserId;
            if (currentUserId == Guid.Empty)
            {
                throw new AppExceptions("User not authenticated");
            }
            var orders = await _unitOfWork.OrderRepository.GetAllAsync(
                predicate: o => o.Id == request.OrderId && o.DependentUserID == currentUserId,
                include: source => source.Include(o => o.OrderDetails)
                    .ThenInclude(od => od.ProductItem)
                );

            var order = orders.FirstOrDefault();
            if (order == null)
            {
                throw new AppExceptions($"Order with ID {request.OrderId} not found");
            }
            if (order.DependentUserID != currentUserId)
            {
                throw new AppExceptions("You do not have permission to update this order");
            }
            var orderDetails = await _unitOfWork.OrderDetailsRepository.GetAllAsync(
                predicate: od => request.OrderDetails.Select(odc => odc.OrderDetailId).Contains(od.Id),
                include: source => source.Include(od => od.ProductItem)
            );
            if (orderDetails.Count() != request.OrderDetails.Count)
            {
                throw new AppExceptions("Some order details not found");
            }
            foreach (var orderDetail in orderDetails)
            {
                var updateItem = request.OrderDetails.First(odc => odc.OrderDetailId == orderDetail.Id);
                orderDetail.Quantity = updateItem.Quantity;
                orderDetail.Notes = updateItem.Notes;
                _unitOfWork.OrderDetailsRepository.Update(orderDetail);
            }
            await _unitOfWork.SaveChangeAsync();
            return order.Id;
        }
    }
}
