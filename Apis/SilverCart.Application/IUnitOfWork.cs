using Infrastructures.Interfaces.Entities;
using Infrastructures.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using SilverCart.Application.Repositories;

namespace Infrastructures
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IStoreRepository StoreRepository { get; }
        public IProductCategoryRepository ProductCategoryRepository { get; }
        public IStoreUserRepository StoreUserRepository { get; }
        public IUserRepository UserRepository { get; }
        public IProductItemRepository ProductItemRepository { get; }
        public IStoreProductItemRepository StoreProductItemRepository { get; }
        public IStoreAddressRepository StoreAddressRepository { get; }
        public ICustomerUserRepository CustomerUserRepository { get; }
        public IOrderItemRepository OrderItemRepository { get; }
        public IDependentUserRepository DependentUserRepository { get; }
        public IGuardianUserRepository GuardianUserRepository { get; }
        public IConversationRepository ConversationRepository { get; }
        public IMessageRepository MessageRepository { get; }
        public IConsultantUserRepository ConsultantUserRepository { get; }
        public Task<IDbContextTransaction> BeginTransactionAsync();
        public Task<int> SaveChangeAsync();
    }
}