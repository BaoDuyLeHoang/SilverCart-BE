using Infrastructures.Commons.Paginations;
using MediatR;
using System;
using System.Collections.Generic;

namespace Infrastructures.Features.Stores.Queries.GetAll
{
    public sealed record GetAllStoresQuery : IRequest<PagedResult<GetAllStoresResponse>>
    {
        public PagingRequest? PagingRequest { get; init; }
        public Guid? Id { get; init; }
        public string? StoreName { get; init; }
        public bool? IsActive { get; init; }
    }

    public record GetAllStoresResponse
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
        public StoreAddressResponse? StoreAddress { get; init; }
    }

    public record StoreAddressResponse
    {
        public Guid Id { get; init; }
        public string StreetAddress { get; init; } = null!;
        public string WardCode { get; init; } = null!;
        public int DistrictId { get; init; }
        public string DistrictName { get; init; } = null!;
        public string ProvinceName { get; init; } = null!;
    }
}