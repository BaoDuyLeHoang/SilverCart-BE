using MediatR;
using System;

namespace Infrastructures.Features.Stores.Commands.Update.UpdateStore
{
    public sealed record UpdateStoreCommand : IRequest<Guid>
    {
        public string StoreName { get; init; } = null!;
        public string Phone { get; init; } = null!;
        // Store info
        public string? Information { get; init; }
        public string? AdditionalInfo { get; init; }
        public string? AvatarPath { get; init; }
        // Address info
        public string StreetAddress { get; init; } = null!;
        public string WardCode { get; init; } = null!;
        public int DistrictId { get; init; }
        public string WardName { get; init; } = null!;
        public string DistrictName { get; init; } = null!;
        public string ProvinceName { get; init; } = null!;
    }
}