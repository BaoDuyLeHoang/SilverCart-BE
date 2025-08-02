using AutoMapper;
using SilverCart.Domain.Entities.Products;
using SilverCart.Domain.Entities;
using Infrastructures.Features.Products.Commands.Create.CreateProduct;

namespace Infrastructures.Mappers
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            // CreateProductCommand -> Product mapping
            CreateMap<CreateProductCommand, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.StoreId, opt => opt.Ignore())
                .ForMember(dest => dest.Store, opt => opt.Ignore())
                .ForMember(dest => dest.ProductCategories, opt => opt.Ignore())
                .ForMember(dest => dest.ProductPromotions, opt => opt.Ignore())
                .ForMember(dest => dest.ProductItems, opt => opt.Ignore())
                .ForMember(dest => dest.ProductImages, opt => opt.Ignore())
                .ForMember(dest => dest.ProductReviews, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.CreationDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModificationDate, opt => opt.Ignore())
                .ForMember(dest => dest.DeletionDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore())
                .ForMember(dest => dest.ModificationById, opt => opt.Ignore())
                .ForMember(dest => dest.DeleteById, opt => opt.Ignore())
                .ForMember(dest => dest.IsHardDelete, opt => opt.Ignore());

            // CreateProductItemsRequest -> ProductItem mapping
            CreateMap<CreateProductItemsRequest, ProductItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ProductId, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.StoreId, opt => opt.Ignore())
                .ForMember(dest => dest.Store, opt => opt.Ignore())
                .ForMember(dest => dest.StockId, opt => opt.Ignore())
                .ForMember(dest => dest.Stock, opt => opt.Ignore())
                .ForMember(dest => dest.StockHistories, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.CreationDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModificationDate, opt => opt.Ignore())
                .ForMember(dest => dest.DeletionDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore())
                .ForMember(dest => dest.ModificationById, opt => opt.Ignore())
                .ForMember(dest => dest.DeleteById, opt => opt.Ignore())
                .ForMember(dest => dest.IsHardDelete, opt => opt.Ignore())
                .ForMember(dest => dest.Value, opt => opt.Ignore())
                .ForMember(dest => dest.Length, opt => opt.Ignore())
                .ForMember(dest => dest.Width, opt => opt.Ignore())
                .ForMember(dest => dest.Height, opt => opt.Ignore())
                .ForMember(dest => dest.ProductName, opt => opt.Ignore());

            // CreateProductItemsImages -> ProductImage mapping
            CreateMap<CreateProductItemsImages, ProductImage>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ProductItemId, opt => opt.Ignore())
                .ForMember(dest => dest.ProductItem, opt => opt.Ignore())
                .ForMember(dest => dest.ProductId, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.CreationDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModificationDate, opt => opt.Ignore())
                .ForMember(dest => dest.DeletionDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore())
                .ForMember(dest => dest.ModificationById, opt => opt.Ignore())
                .ForMember(dest => dest.DeleteById, opt => opt.Ignore())
                .ForMember(dest => dest.IsHardDelete, opt => opt.Ignore());
        }
    }
} 