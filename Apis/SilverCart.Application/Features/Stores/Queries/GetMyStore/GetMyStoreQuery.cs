using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Stores.Queries.GetMyStore
{
    public sealed record GetMyStoreQueryCommand : IRequest<GetMyStoreQueryResponse>;
    public record GetMyStoreQueryResponse(string Name, string? Infomation, string AvatarPath, string? AdditionalInfo, int? GhnShopId, string Phone, GetStoreAddressResponse Address);
    public record GetStoreAddressResponse(string FullAddress, string StreetAddress, string WardCode, int DistrictId, string? DistrictName, string? ProvinceName, string? WardName);
    public class GetMyStoreQuery(IUnitOfWork unitOfWork) : IRequestHandler<GetMyStoreQueryCommand, GetMyStoreQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<GetMyStoreQueryResponse> Handle(GetMyStoreQueryCommand request, CancellationToken cancellationToken)
        {
            var stores = await _unitOfWork.StoreRepository.GetAllAsync(
                predicate: x => x.Id == Guid.Parse("c4f31cea-14f3-45cd-98ad-39d68e78e0e7"), //Change after host
                include: x => x.Include(s => s.StoreAddress)
                );

            var store = stores.FirstOrDefault();
            return store == null
                ? throw new AppExceptions("Store not found")
                : new GetMyStoreQueryResponse(
                    store.Name,
                    store.Description,
                    store.AvatarPath,
                    store.AdditionalInfo,
                    store.GhnShopId,
                    store.Phone,
                    new GetStoreAddressResponse(
                        store.StoreAddress.FullAddress,
                        store.StoreAddress.StreetAddress,
                        store.StoreAddress.WardCode,
                        store.StoreAddress.DistrictId,
                        store.StoreAddress.DistrictName,
                        store.StoreAddress.ProvinceName,
                        store.StoreAddress.WardName
                    )
                );
        }
    }
}
