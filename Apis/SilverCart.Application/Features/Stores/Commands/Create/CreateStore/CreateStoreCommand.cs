using MediatR;
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
}