// // using AutoMapper;
// using SilverCart.Domain.Entities;
// using SilverCart.Domain.Enums;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace Infrastructures.Mappers
// {
//     public class ProductMapperProfile : Profile
//     {
//         public ProductMapperProfile()
//         {
//             CreateMap<CreateProductVM, Product>()
//                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
//                 .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType ?? ProductTypeEnum.Physical))
//                 .ForMember(dest => dest.Images, opt => opt.Ignore())
//                 .ForMember(dest => dest.Variants, opt => opt.Ignore());

//             CreateMap<ProductImageVM, ProductImage>()
//                 .ForMember(dest => dest.Id, opt => opt.Ignore());

//             CreateMap<ProductItemsVM, ProductItem>()
//                 .ForMember(dest => dest.Id, opt => opt.Ignore())
//                 .ForMember(dest => dest.VariantId, opt => opt.Ignore());

//             CreateMap<ProductVariantVM, ProductVariant>()
//                 .ForMember(dest => dest.Id, opt => opt.Ignore())
//                 .ForMember(dest => dest.ProductId, opt => opt.Ignore())
//                 .ForMember(dest => dest.Items, opt => opt.Ignore());

//             CreateMap<UpdateProductImageVM, ProductImage>();
//             CreateMap<UpdateProductItemsVM, ProductItem>();
//         }
//     }
// }
