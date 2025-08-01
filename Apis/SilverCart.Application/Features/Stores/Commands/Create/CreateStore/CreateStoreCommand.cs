using MediatR;
using SilverCart.Domain.Enums;
using System;

namespace Infrastructures.Features.Stores.Commands.Create.CreateStore
{
    public sealed record CreateStoreCommand : IRequest<Guid>
    {
        public string StoreName { get; init; } = null!;
        // Address info
        public string StreetAddress { get; init; } = null!;
        public string WardCode { get; init; } = null!;
        public int DistrictId { get; init; }
        public string WardName { get; init; } = null!;
        public string DistrictName { get; init; } = null!;
        public string ProvinceName { get; init; } = null!;
        // Store info
        public string? Information { get; init; }
        public string? AdditionalInfo { get; init; }
        public string? AvatarPath { get; init; }
    }
    public sealed record CreateStoreGhnRequest
    {
        public int DistrictId { get; init; }
        public string WardCode { get; init; } = null!;
        public string ShopName { get; init; } = null!;
        public string ShopPhone { get; init; } = null!;
        public string ShopAddress { get; init; } = null!;
    }
    public sealed record CreateOrderShippingGhnRequest
    {
        public int ShopId { get; init; }
        public string ToName { get; init; } = null!; //ClientName
        public string FromName { get; init; } = null!; //StoreName
        public string FromPhone { get; init; } = null!;
        public string FromAddress { get; init; } = null!;
        public string FromWardName { get; init; } = null!;
        public string FromDistrictName { get; init; } = null!;
        public string FromProvinceName { get; init; } = null!;
        public string ToPhone { get; init; } = null!;
        public string ToAddress { get; init; } = null!;
        public string ToWardCode { get; init; } = null!;
        public int ToDistrictId { get; init; }
        public string? ReturnPhone { get; init; }
        public string? ReturnAddress { get; init; }
        public int? ReturnDistrictId { get; init; }
        public string? ReturnWardCode { get; init; }
        public string? ClientOrderCode { get; init; } // Mã đơn hàng của khách hàng
        public int CodAmount { get; init; }
        public string Content { get; init; } = null!; // Nội dung đơn hàng
        public int Weight { get; init; }
        public int Length { get; init; }
        public int Width { get; init; }
        public int Height { get; init; }
        public int ServiceTypeId { get; init; } //https://api.ghn.vn/home/docs/detail?id=77
        public int PaymentTypeId { get; init; } //Shipping Fee: 1: seller, 2: buyer
        public string RequireNote { get; init; } = GhnRequireNoteEnum.KHONGCHOXEMHANG.ToString();
        public List<OrderItemsToDelivery> OrderItems { get; set; } = new List<OrderItemsToDelivery>();
    }
    public sealed record OrderItemsToDelivery
    {
        public string Name { get; init; } = null!;
        public int Quantity { get; init; }
        public int Weight { get; init; }
    }
}