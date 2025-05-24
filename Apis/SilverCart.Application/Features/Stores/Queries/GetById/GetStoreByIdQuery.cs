using MediatR;
using System;
using System.Collections.Generic;

namespace Infrastructures.Features.Stores.Queries.GetById
{
    public sealed record GetStoreByIdQuery(Guid Id) : IRequest<GetStoreByIdResponse>;

    public record GetStoreByIdResponse
    {
        public Guid Id { get; init; }
        public string StoreName { get; init; } = null!;
        public string? Information { get; init; }
        public string AvatarPath { get; init; } = null!;
        public string? AdditionalInfo { get; init; }
        public bool IsActive { get; init; }
        public bool IsGhnSynced { get; init; }
        public int? GhnShopId { get; init; }
        public DateTime? CreatedDate { get; init; }
        public StoreAddressDetailResponse? StoreAddress { get; init; }
        public List<StoreUserResponse> StoreUsers { get; init; } = new List<StoreUserResponse>();
    }

    public record StoreAddressDetailResponse
    {
        public Guid Id { get; init; }
        public string StreetAddress { get; init; } = null!;
        public string WardCode { get; init; } = null!;
        public int DistrictId { get; init; }
        public string DistrictName { get; init; } = null!;
        public string ProvinceName { get; init; } = null!;
    }

    public record StoreUserResponse
    {
        public Guid Id { get; init; }
        public string? UserName { get; init; }
        public string? FullName { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
    }
}