using SilverCart.Application.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Infrastructures.Interfaces.Repositories;
using Infrastructures.Interfaces.Entities;
using Infrastructures.Interfaces.System;

namespace Infrastructures
{
    public class UnitOfWork(AppDbContext dbContext, IAdministratorUserRepository administratorUserRepository,
                            ICategoryRepository categoryRepository, IConsultantUserRepository consultantUserRepository,
                            IConsultationRepository consultationRepository, IConversationRepository conversationRepository,
                            ICustomerUserRepository customerUserRepository, IDependentUserRepository dependentUserRepository,
                            IGuardianUserRepository guardianUserRepository, IMessageRepository messageRepository,
                            IOrderDetailsRepository orderDetailsRepository, IOrderRepository orderRepository,
                            IOTPRepository otpRepository, IPaymentRepository paymentRepository,
                            IProductCategoryRepository productCategoryRepository, IProductItemRepository productItemRepository,
                            IProductRepository productRepository, IProductVariantRepository productVariantRepository,
                            IStoreAddressRepository storeAddressRepository, IStoreRepository storeRepository,
                            IStoreUserRepository storeUserRepository, IUserRepository userRepository) : IUnitOfWork
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
        public IProductVariantRepository ProductVariantRepository => productVariantRepository;
        public IOTPRepository OTPRepository => otpRepository;
        public IConsultantUserRepository ConsultantUserRepository => consultantUserRepository;
        public IConsultationRepository ConsultationRepository => consultationRepository;
        public IAdministratorUserRepository AdministratorUserRepository => administratorUserRepository;
        public IPaymentRepository PaymentRepository => paymentRepository;

        // Transaction methods
        public async Task<IDbContextTransaction> BeginTransactionAsync() => await dbContext.Database.BeginTransactionAsync();
        public async Task CommitTransactionAsync() => await dbContext.Database.CommitTransactionAsync();
        public async Task RollbackTransactionAsync() => await dbContext.Database.RollbackTransactionAsync();
        public async Task<int> SaveChangeAsync() => await dbContext.SaveChangesAsync();
    }
}