//using SilverCart.Application.ViewModels.CategorysViewModels;
//using AutoMapper;
//using SilverCart.Application.Commons;
//using SilverCart.Domain.Entities;
//using Infrastructures.ViewModels.CategoryViewModels;

//namespace Infrastructures.Mappers
//{
//    public class CategoryMapperProfile : Profile
//    {
//        public CategoryMapperProfile()
//        {
//            CreateMap(typeof(Pagination<>), typeof(Pagination<>));
//            CreateMap<Category, CategoryVM>();

//            CreateMap<CategoryVM.Create, Category>()
//                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName))
//                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.CategoryDescription))
//                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.CategoryStatusEnum))
//                .ForMember(dest => dest.ParentCategoryId, opt => opt.MapFrom(src => src.ParentCategoryId));

//            CreateMap<CategoryVM.Update, Category>()
//                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName))
//                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.CategoryDescription))
//                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.CategoryStatusEnum))
//                .ForMember(dest => dest.ParentCategoryId, opt => opt.MapFrom(src => src.ParentCategoryId));

//            CreateMap<CategoryVM.View, Category>()
//                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName))
//                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.CategoryDescription))
//                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.CategoryStatusEnum))
//                .ForMember(dest => dest.ParentCategoryId, opt => opt.MapFrom(src => src.ParentCategoryId));
//        }
//    }
//}