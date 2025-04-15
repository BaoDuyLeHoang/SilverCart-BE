using Application.ViewModels.CategorysViewModels;
using AutoMapper;
using Application.Commons;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class MapperConfigurationsProfile : Profile
    {
        public MapperConfigurationsProfile()
        {
            // CreateMap<CreateCategoryViewModel, Category>();
            CreateMap(typeof(Pagination<>), typeof(Pagination<>));
            CreateMap<Category, CategoryViewModel>();
            // .ForMember(dest => dest._Id, src => src.MapFrom(x => x.Id));
        }
    }
}
