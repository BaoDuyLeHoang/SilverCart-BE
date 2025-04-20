using Application.ViewModels.CategorysViewModels;
using AutoMapper;
using Application.Commons;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class CommonMapperProfile : Profile
    {
        public CommonMapperProfile()
        {
            CreateMap(typeof(Pagination<>), typeof(Pagination<>));
            CreateMap<Category, CategoryViewModel>();
        }
    }
}