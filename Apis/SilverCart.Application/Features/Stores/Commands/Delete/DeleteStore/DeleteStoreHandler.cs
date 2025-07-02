using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructures.Features.Stores.Commands.Delete.DeleteStore
{
    public class DeleteStoreHandler : IRequestHandler<DeleteStoreCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;

        public DeleteStoreHandler(
            IUnitOfWork unitOfWork,
            IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
        }

        public async Task<Guid> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            var userId = _claimsService.CurrentUserId;
            var storeUserQuery = await _unitOfWork.StoreUserRepository
                .GetAllAsync(x => x.Id == userId && x.StoreId == request.Id);

            var storeUser = await storeUserQuery.FirstOrDefaultAsync(cancellationToken);

            if (storeUser == null)
            {
                throw new AppExceptions("You don't have permission to delete this store");
            }

            var store = await _unitOfWork.StoreRepository.GetByIdAsync(request.Id);
            if (store == null)
            {
                throw new AppExceptions("Store not found");
            }

            // Soft delete store
            store.IsDeleted = true;
            store.DeletionDate = DateTime.UtcNow;
            store.DeleteById = userId;
            _unitOfWork.StoreRepository.SoftRemove(store);

            // Unbind users from this store
            var storeUsersQuery = await _unitOfWork.StoreUserRepository
                .GetAllAsync(x => x.StoreId == request.Id);

            var storeUsers = await storeUsersQuery.ToListAsync(cancellationToken);

            foreach (var user in storeUsers)
            {
                user.IsDeleted = true;
                user.DeletionDate = DateTime.UtcNow;
                user.DeleteById = userId;
            }

            _unitOfWork.StoreUserRepository.SoftRemoveRange(storeUsers);

            await _unitOfWork.SaveChangeAsync();
            return request.Id;
        }
    }
}