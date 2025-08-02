using SilverCart.Application.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Infrastructures.Interfaces.Repositories;
using Infrastructures.Interfaces.Entities;
using Infrastructures.Interfaces.System;
using SilverCart.Application.Interfaces.Repositories;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        private readonly IAdministratorUserRepository administratorUserRepository;
        private readonly IAddressRepository addressRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IConsultantUserRepository consultantUserRepository;
        private readonly IConsultationRepository consultationRepository;
        private readonly IConversationRepository conversationRepository;
        private readonly ICustomerUserRepository customerUserRepository;
        private readonly IDependentUserRepository dependentUserRepository;
        private readonly IGuardianUserRepository guardianUserRepository;
        private readonly IMessageRepository messageRepository;
        private readonly IOrderDetailsRepository orderDetailsRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IOTPRepository otpRepository;
        private readonly IPaymentRepository paymentRepository;
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IProductItemRepository productItemRepository;
        private readonly IProductRepository productRepository;
        private readonly IProductImageRepository productImageRepository;
        private readonly IStoreAddressRepository storeAddressRepository;
        private readonly IStoreRepository storeRepository;
        private readonly IStoreUserRepository storeUserRepository;
        private readonly IUserRepository userRepository;
        private readonly IUserPromotionRepository userPromotionRepository;
        private readonly IReportRepository reportRepository;
        private readonly ICartRepository cartRepository;
        private readonly ICartItemRepository cartItemRepository;
        private readonly IWalletRepository walletRepository;
        private readonly IPaymentHistoryRepository paymentHistoryRepository;
        private readonly IPromotionRepository promotionRepository;

        public UnitOfWork(AppDbContext dbContext,
                          IAdministratorUserRepository administratorUserRepository, IAddressRepository addressRepository,
                          ICategoryRepository categoryRepository, IConsultantUserRepository consultantUserRepository,
                          IConsultationRepository consultationRepository, IConversationRepository conversationRepository,
                          ICustomerUserRepository customerUserRepository, IDependentUserRepository dependentUserRepository,
                          IGuardianUserRepository guardianUserRepository, IMessageRepository messageRepository,
                          IOrderDetailsRepository orderDetailsRepository, IOrderRepository orderRepository,
                          IOTPRepository otpRepository, IPaymentRepository paymentRepository,
                          IProductCategoryRepository productCategoryRepository, IProductItemRepository productItemRepository,
                          IProductRepository productRepository, IProductImageRepository productImageRepository,
                          IStoreAddressRepository storeAddressRepository, IStoreRepository storeRepository,
                          IStoreUserRepository storeUserRepository, IUserRepository userRepository,
                          IUserPromotionRepository userPromotionRepository, IReportRepository reportRepository,
                          ICartRepository cartRepository, ICartItemRepository cartItemRepository,
                          IWalletRepository walletRepository, IPaymentHistoryRepository paymentHistoryRepository,
                          IPromotionRepository promotionRepository)
        {
            this.dbContext = dbContext;
            this.administratorUserRepository = administratorUserRepository;
            this.addressRepository = addressRepository;
            this.categoryRepository = categoryRepository;
            this.consultantUserRepository = consultantUserRepository;
            this.consultationRepository = consultationRepository;
            this.conversationRepository = conversationRepository;
            this.customerUserRepository = customerUserRepository;
            this.dependentUserRepository = dependentUserRepository;
            this.guardianUserRepository = guardianUserRepository;
            this.messageRepository = messageRepository;
            this.orderDetailsRepository = orderDetailsRepository;
            this.orderRepository = orderRepository;
            this.otpRepository = otpRepository;
            this.paymentRepository = paymentRepository;
            this.productCategoryRepository = productCategoryRepository;
            this.productItemRepository = productItemRepository;
            this.productRepository = productRepository;
            this.productImageRepository = productImageRepository;
            this.storeAddressRepository = storeAddressRepository;
            this.storeRepository = storeRepository;
            this.storeUserRepository = storeUserRepository;
            this.userRepository = userRepository;
            this.userPromotionRepository = userPromotionRepository;
            this.reportRepository = reportRepository;
            this.cartRepository = cartRepository;
            this.cartItemRepository = cartItemRepository;
            this.walletRepository = walletRepository;
            this.paymentHistoryRepository = paymentHistoryRepository;
            this.promotionRepository = promotionRepository;
        }

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
        public IWalletRepository WalletRepository => walletRepository;
        public IPaymentHistoryRepository PaymentHistoryRepository => paymentHistoryRepository;
        public IPromotionRepository PromotionRepository => promotionRepository;

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