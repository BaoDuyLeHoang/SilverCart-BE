using Infrastructures.Interfaces.Entities;
using Infrastructures.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using SilverCart.Application.Interfaces.Repositories;
using SilverCart.Application.Repositories;

namespace Infrastructures
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IOrderDetailsRepository OrderDetailsRepository { get; }
        public IProductRepository ProductRepository { get; }

        public IStoreRepository StoreRepository { get; }
        public IProductCategoryRepository ProductCategoryRepository { get; }
        public IStoreUserRepository StoreUserRepository { get; }
        public IUserRepository UserRepository { get; }
        public IProductItemRepository ProductItemRepository { get; }
        //public IStoreProductItemRepository StoreProductItemRepository { get; }
        public IStoreAddressRepository StoreAddressRepository { get; }
        public ICustomerUserRepository CustomerUserRepository { get; }
        public IDependentUserRepository DependentUserRepository { get; }
        public IGuardianUserRepository GuardianUserRepository { get; }
        public IConversationRepository ConversationRepository { get; }
        public IMessageRepository MessageRepository { get; }
        public IAddressRepository AddressRepository { get; }
        //public IStoreOrderRepository StoreOrderRepository { get; }
        //public IStoreProductItemOrderRepository StoreProductItemOrderRepository { get; }
        public IConsultantUserRepository ConsultantUserRepository { get; }
        public IConsultationRepository ConsultationRepository { get; }
        public IAdministratorUserRepository AdministratorUserRepository { get; }
        public IUserPromotionRepository UserPromotionRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
        public IReportRepository ReportRepository { get; }
        public IProductImageRepository ProductImageRepository { get; }
        public ICartRepository CartRepository { get; }
        public ICartItemRepository CartItemRepository { get; }
        public IWalletRepository WalletRepository { get; }
        public IPaymentHistoryRepository PaymentHistoryRepository { get; }
        public IProductPromotionRepository ProductPromotionRepository { get; }
        public IPromotionRepository PromotionRepository { get; }

        // Transaction methods
        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
        public Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
        public Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        public Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}