using SilverCart.Application.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Infrastructures.Interfaces.Repositories;
using Infrastructures.Interfaces.Entities;
using Infrastructures.Interfaces.System;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IStoreUserRepository _storeUserRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductItemRepository _productItemRepository;
        private readonly IStoreProductItemRepository _storeProductItemRepository;
        private readonly IStoreAddressRepository _storeAddressRepository;
        private readonly ICustomerUserRepository _customerUserRepository;
        private readonly IDependentUserRepository _dependentUserRepository;
        private readonly IGuardianUserRepository _guardianUserRepository;
        private readonly IConversationRepository _conversationRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IStoreOrderRepository _storeOrderRepository;
        private readonly IStoreProductItemOrderRepository _storeProductItemOrderRepository;
        private readonly IConsultantUserRepository _consultantUserRepository;
        private readonly IConsultationRepository _consultationRepository;
        public UnitOfWork(AppDbContext dbContext,
            ICategoryRepository categoryRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IStoreRepository storeRepository,
            IProductCategoryRepository productCategoryRepository,
            IStoreUserRepository storeUserRepository,
            IUserRepository userRepository,
            IProductItemRepository productItemRepository,
            IStoreProductItemRepository storeProductItemRepository,
            IStoreAddressRepository storeAddressRepository,
            ICustomerUserRepository customerUserRepository,
            IDependentUserRepository dependentUserRepository,
            IGuardianUserRepository guardianUserRepository,
            IConversationRepository conversationRepository,
            IMessageRepository messageRepository,
            IStoreOrderRepository storeOrderRepository,
            IStoreProductItemOrderRepository storeProductItemOrderRepository,
            IConsultantUserRepository consultantUserRepository,
            IConsultationRepository consultationRepository)
        {
            _dbContext = dbContext;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _storeRepository = storeRepository;
            _productCategoryRepository = productCategoryRepository;
            _storeUserRepository = storeUserRepository;
            _userRepository = userRepository;
            _productItemRepository = productItemRepository;
            _storeProductItemRepository = storeProductItemRepository;
            _storeAddressRepository = storeAddressRepository;
            _customerUserRepository = customerUserRepository;
            _dependentUserRepository = dependentUserRepository;
            _guardianUserRepository = guardianUserRepository;
            _conversationRepository = conversationRepository;
            _messageRepository = messageRepository;
            _storeOrderRepository = storeOrderRepository;
            _storeProductItemOrderRepository = storeProductItemOrderRepository;
            _consultantUserRepository = consultantUserRepository;
            _consultationRepository = consultationRepository;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository;
        public IOrderRepository OrderRepository => _orderRepository;
        public IProductRepository ProductRepository => _productRepository;
        public IStoreRepository StoreRepository => _storeRepository;
        public IProductCategoryRepository ProductCategoryRepository => _productCategoryRepository;
        public IStoreUserRepository StoreUserRepository => _storeUserRepository;
        public IUserRepository UserRepository => _userRepository;
        public IProductItemRepository ProductItemRepository => _productItemRepository;
        public IStoreProductItemRepository StoreProductItemRepository => _storeProductItemRepository;
        public IStoreAddressRepository StoreAddressRepository => _storeAddressRepository;
        public ICustomerUserRepository CustomerUserRepository => _customerUserRepository;
        public IDependentUserRepository DependentUserRepository => _dependentUserRepository;
        public IGuardianUserRepository GuardianUserRepository => _guardianUserRepository;

        public IConversationRepository ConversationRepository => _conversationRepository;

        public IMessageRepository MessageRepository => _messageRepository;

        public IStoreOrderRepository StoreOrderRepository => _storeOrderRepository;

        public IStoreProductItemOrderRepository StoreProductItemOrderRepository => _storeProductItemOrderRepository;

        public IConsultantUserRepository ConsultantUserRepository => _consultantUserRepository;
        public IConsultationRepository ConsultationRepository => _consultationRepository;
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }


        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}