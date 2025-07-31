using SilverCart.Application.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Infrastructures.Interfaces.Repositories;
using Infrastructures.Interfaces.Entities;
using Infrastructures.Interfaces.System;
using SilverCart.Application.Interfaces.Repositories;

namespace Infrastructures
{
    public class UnitOfWork(AppDbContext dbContext,
                            IAdministratorUserRepository administratorUserRepository, IAddressRepository addressRepository,
                            ICategoryRepository categoryRepository, IConsultantUserRepository consultantUserRepository,
                            IConsultationRepository consultationRepository, IConversationRepository conversationRepository,
                            ICustomerUserRepository customerUserRepository, IDependentUserRepository dependentUserRepository,
                            IGuardianUserRepository guardianUserRepository, IMessageRepository messageRepository,
                            IOrderDetailsRepository orderDetailsRepository, IOrderRepository orderRepository,
                            IOTPRepository otpRepository, IPaymentRepository paymentRepository,
                            IProductCategoryRepository productCategoryRepository, IProductItemRepository productItemRepository,
                            IProductRepository productRepository,
                            IProductImageRepository productImageRepository,
                            IStoreAddressRepository storeAddressRepository, IStoreRepository storeRepository,
                            IStoreUserRepository storeUserRepository, IUserRepository userRepository,
                            IUserPromotionRepository userPromotionRepository, IReportRepository reportRepository,
                            ICartRepository cartRepository, ICartItemRepository cartItemRepository) : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository => categoryRepository;
        public IOrderRepository OrderRepository => orderRepository;
        public IProductRepository ProductRepository => productRepository;
        public IStoreRepository StoreRepository => storeRepository;
        public IProductCategoryRepository ProductCategoryRepository => productCategoryRepository;
        public IStoreUserRepository StoreUserRepository => storeUserRepository;
        public IUserRepository UserRepository => userRepository;
        public IProductItemRepository ProductItemRepository => productItemRepository;
        public IStoreAddressRepository StoreAddressRepository => storeAddressRepository;
        public ICustomerUserRepository CustomerUserRepository => customerUserRepository;
        public IDependentUserRepository DependentUserRepository => dependentUserRepository;
        public IGuardianUserRepository GuardianUserRepository => guardianUserRepository;
        public IConversationRepository ConversationRepository => conversationRepository;
        public IMessageRepository MessageRepository => messageRepository;
        public IOrderDetailsRepository OrderDetailsRepository => orderDetailsRepository;

        public IOTPRepository OTPRepository => otpRepository;
        public IConsultantUserRepository ConsultantUserRepository => consultantUserRepository;
        public IConsultationRepository ConsultationRepository => consultationRepository;
        public IAdministratorUserRepository AdministratorUserRepository => administratorUserRepository;
        public IPaymentRepository PaymentRepository => paymentRepository;
        public IAddressRepository AddressRepository => addressRepository;

        public IUserPromotionRepository UserPromotionRepository => userPromotionRepository;

        public IReportRepository ReportRepository => reportRepository;
        public IProductImageRepository ProductImageRepository => productImageRepository;
        public ICartRepository CartRepository => cartRepository;
        public ICartItemRepository CartItemRepository => cartItemRepository;
        // Transaction methods
        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default) => await dbContext.Database.BeginTransactionAsync(cancellationToken);
        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default) => await dbContext.Database.CommitTransactionAsync(cancellationToken);
        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (dbContext.Database.CurrentTransaction != null)
                await dbContext.Database.RollbackTransactionAsync(cancellationToken);
        }

        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken = default) => await dbContext.SaveChangesAsync(cancellationToken);
    }
}