# CHANGELOG - SilverCart Project

## 📅 Date: 2025-01-XX

### StoreUserRole Removal and Order API Fixes
    - **COMPLETELY REMOVED StoreUserRole Entity:**
      - ✅ Deleted StoreUserRole.cs entity file
      - ✅ Deleted IStoreUserRoleRepository.cs interface
      - ✅ Deleted StoreUserRoleRepository.cs implementation
      - ✅ Removed StoreUserRole from IUnitOfWork and UnitOfWork
      - ✅ Removed StoreUserRoles DbSet from AppDbContext
      - ✅ Removed StoreUserRoles navigation property from StoreUser entity
      - ✅ Removed StoreUserRoles navigation property from StoreRole entity
      - ✅ Removed StoreUserRole configuration from FluentAPIs
      - ✅ Updated SeedDataExtension.cs to remove all StoreUserRole references
      - ✅ Updated GetStoreUserQuery.cs to work without StoreUserRole
    
    - **DATABASE MIGRATION:**
      - ✅ Applied FixOrderRelationships migration
      - ✅ Dropped StoreUserRoles table from database
      - ✅ Added CustomerUserId column to Orders table
      - ✅ Created proper foreign key constraints for Order relationships
    
    - **ORDER API FIXES:**
      - ✅ Fixed GetOrderByIdQuery.cs null reference issues
      - ✅ Added proper Include statements for Stock navigation property
      - ✅ Added null checks for Stock.Quantity and CreationDate
      - ✅ Fixed CalculateShippingFeeHandler.cs FormStoreId property error
      - ✅ Updated shipping fee calculation to use Product.StoreId instead
    
    - **ENTITY CONFIGURATION FIXES:**
      - ✅ Fixed OrderConfiguration.cs incomplete relationship mappings
      - ✅ Added proper foreign key specifications for ConfirmUser, OrderedUser, RecieveUser
      - ✅ Set foreign keys as nullable (IsRequired(false)) for optional relationships
    
    - **BUILD STATUS:** ✅ Successful - No compilation errors
    - **DATABASE STATUS:** ✅ Migration applied successfully
    - **API STATUS:** ✅ Order endpoints now working without 500 errors
    - **IMPORTANT:** StoreUserRole completely removed, Order API fully functional

## 📅 Date: 2025-08-02

### Dependency Injection Fix - ClaimsService Resolution
    - **FIXED ClaimsService Dependency Injection:**
      - ✅ Changed UserRepository injection to IUserRepository in ClaimsService constructor
      - ✅ Added using Infrastructures.Interfaces.Repositories to ClaimsService.cs
      - ✅ Resolved "Unable to resolve service for type 'Infrastructures.Repositories.UserRepository'" error
      - ✅ Fixed dependency injection container registration issue
      - ✅ Build successful with no compilation errors
    
    - **ROOT CAUSE:**
      - ClaimsService was injecting concrete UserRepository instead of IUserRepository interface
      - Missing using statement for Infrastructures.Interfaces.Repositories namespace
      - Dependency injection container couldn't resolve the concrete type properly
    
    - **SOLUTION:**
      - Updated ClaimsService constructor to use IUserRepository interface
      - Added proper using statement for namespace containing IUserRepository
      - Maintained existing functionality while fixing injection pattern
    
    - **BUILD STATUS:** ✅ Successful - No compilation errors
    - **IMPORTANT:** API endpoints now properly resolve ClaimsService dependency

### Entity Hierarchy Refactoring - Final Implementation
    - **COMPLETED Entity Hierarchy Restructure:**
      - ✅ DependentUser and GuardianUser now inherit from CustomerUser
      - ✅ CustomerUser inherits from BaseUser and contains all customer-specific functionality
      - ✅ Moved all customer-specific navigation properties from BaseUser to CustomerUser
    
    - **RELATIONSHIP FIELD REFACTORING:**
      - ✅ Changed Relationship from RelationshipEnum? to string? in DependentUser
      - ✅ Updated all Application layer files to use string instead of enum
      - ✅ Modified GetDetailUserQuery, GetAllUsersQuery, UpdateDependentUserCommand, CreateDependentUserHandler
      - ✅ All DTOs and responses now use string? for Relationship field
    
    - **DATABASE MIGRATION:**
      - ✅ Created RefactorEntityHierarchyAndCustomerUserImplementationFinal migration
      - ✅ Successfully applied migration to database
      - ✅ Relationship column in DependentUsers table is now text (string) type
      - ✅ All foreign key relationships properly established
    
    - **SEED DATA UPDATES:**
      - ✅ Updated SeedDataExtension.cs to reflect new entity hierarchy
      - ✅ Added _relationshipTypes array with Vietnamese relationship names
      - ✅ Updated DependentUser creation to include new fields (DateOfBirth, Relationship as string, MedicalNotes, MonthlySpendingLimit, SuggestedCategoryIds)
      - ✅ Updated GuardianUser and DependentUser creation to inherit from CustomerUser
      - ✅ Updated customer faker to include new DependentUser fields
      - ✅ Updated order creation to use all CustomerUser types (DependentUser, GuardianUser)
      - ✅ Removed ConsultantRole references from seed data
      - ✅ Fixed Wallet foreign key constraint issue by creating Wallet after user creation with correct UserId
      - ✅ Added Wallet creation for all CustomerUser types (GuardianUser, DependentUser) in seed data
    
    - **BUILD STATUS:** ✅ Successful - No compilation errors
    - **DATABASE STATUS:** ✅ Migration applied successfully
    - **IMPORTANT:** Entity hierarchy now properly encapsulates customer functionality

## 📅 Date: 2025-01-XX

### Entity Architecture Refactoring - CustomerUser Implementation
    - **REFACTORED Entity Hierarchy:**
      - Changed DependentUser inheritance: BaseUser → CustomerUser
      - Changed GuardianUser inheritance: BaseUser → CustomerUser
      - CustomerUser now inherits from BaseUser and contains all customer-specific functionality
    
    - **MOVED Navigation Properties from BaseUser to CustomerUser:**
      - Orders (with new keyword to hide BaseUser.Orders)
      - Carts (with new keyword to hide BaseUser.Carts)
      - PaymentHistories (with new keyword to hide BaseUser.PaymentHistories)
      - UserPromotions (with new keyword to hide BaseUser.UserPromotions)
      - Wallet (with new keyword to hide BaseUser.Wallet)
    
    - **ADDED Customer-specific Properties to CustomerUser:**
      - RankId (Guid)
      - CustomerPaymentMethods (ICollection<CustomerPaymentMethod>)
      - CustomerAddresses (ICollection<CustomerAddress>)
    
    - **REMOVED Duplicate Properties from DependentUser:**
      - RankId (now inherited from CustomerUser)
      - CustomerPaymentMethods (now inherited from CustomerUser)
      - CustomerAddresses (now inherited from CustomerUser)
    
    - **REMOVED Duplicate Properties from GuardianUser:**
      - Carts (now inherited from CustomerUser)
    
    - **UPDATED BaseUser to contain only common properties:**
      - Kept: Addresses, ConversationMemberships (common for all users)
      - Removed: Orders, Carts, PaymentHistories, UserPromotions, Wallet (customer-specific)
    
    - **NEW Entity Hierarchy:**
      ```
      BaseUser (common properties)
      └── CustomerUser (customer-specific properties)
          ├── DependentUser (dependent-specific properties)
          └── GuardianUser (guardian-specific properties)
      ```
    
    - **BUILD STATUS:** ✅ Successful - No compilation errors
    - **IMPORTANT:** All customer functionality now properly encapsulated in CustomerUser

## 📅 Date: 2025-07-31

### Cart Module - Cleanup redundant files
    - Removed AddToCart module (Command, Handler, Validator)
    - Removed ClearCart module (Command, Handler)
    - Removed duplicate GetCart files from Commands folder
    - Updated CartController to remove AddToCart endpoint
    - Kept only GetCart in Queries folder
    - Build successful after cleanup

### DependentUser Entity - Add new fields and CRUD
    - Created RelationshipEnum with 10 relationship types
    - Added ImageUrl field to BaseUser entity
    - Added 6 new fields to DependentUser: DateOfBirth, Relationship, MedicalNotes, MonthlySpendingLimit, AddressId, SuggestedCategoryIds
    - Created UpdateDependentUserCommand and Handler
    - Updated CreateDependentUserHandler with new fields
    - Added PUT /api/user/dependent-user/{id} endpoint
    - Added PUT /api/user/update-image endpoint for image upload
    - Created database migration AddDependentUserFields
    - All new fields are optional for backward compatibility

### User Management - Image upload functionality
    - Created UpdateImageUrlCommand with IFormFile parameter
    - Created UpdateImageUrlHandler using FirebaseFileService
    - Added transaction support with IUnitOfWork
    - Uploads images to "user-avatars" folder on Firebase
    - Updates ImageUrl in BaseUser entity
    - Added proper error handling and rollback
    - Enhanced response with additional user fields (Gender, CreationDate, ModificationDate)

### Database Schema - Migration updates
    - Added 6 new columns to DependentUsers table
    - Added ImageUrl column to AspNetUsers table
    - Migration applied successfully
    - IMPORTANT: Run database update before testing new features!!!

### API Endpoints - New user management features
    - POST /api/user/dependent-user (Guardian role) - Create multiple dependent users
    - PUT /api/user/dependent-user/{id} (Guardian,Admin,SuperAdmin roles) - Update dependent user
    - PUT /api/user/update-image (Authorize) - Upload user avatar
    - All endpoints include proper authorization and validation
    - Support for multipart/form-data for image uploads

### Repository Layer - Add WalletRepository
    - Created IWalletRepository interface following existing pattern
    - Created WalletRepository implementation inheriting from GenericRepository<Wallet>
    - Added IWalletRepository to IUnitOfWork interface
    - Added WalletRepository to UnitOfWork constructor and property
    - Registered IWalletRepository in DependencyInjection
    - Build successful with no compilation errors
    - IMPORTANT: WalletRepository now available for use in handlers!!!

### Payment System - Implement IPN for Wallet top-up
    - Fixed CreatePaymentCommand parameter order (optional parameters after required)
    - Created AddToWalletCommand and AddToWalletHandler for IPN processing
    - Updated PaymentController IPNReturn endpoint to use AddToWalletCommand
    - Added proper error handling and response structure
    - Fixed CreatePaymentHandler GetByIdAsync method call
    - Updated AddToWalletCommand to use PaymentResponse directly
    - Simplified PaymentController to pass PaymentResponse to command
    - Build successful with all warnings being nullable reference warnings
    - IMPORTANT: IPN endpoint now properly processes VNPAY callbacks!!!

### Build Status - Project stability
    - Build successful with no compile errors
    - All warnings are nullable reference warnings (non-critical)
    - Transaction support implemented for data integrity
    - Role-based access control properly implemented
    - Backward compatibility maintained for existing features 