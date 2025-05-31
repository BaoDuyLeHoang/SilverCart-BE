/*using AutoMapper;
using Infrastructures.ViewModels.StoreViewModels;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Mappers
{
    public class StoreMapperProfile : Profile
    {
        public StoreMapperProfile()
        {
            CreateMap<CreateStoreVM, Store>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.StoreName))
                .ForMember(dest => dest.IsBanned, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.IsVerified, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.StoreUsers, opt => opt.Ignore());

            CreateMap<ViewStoreVMRequest, Store>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.StoreName))
                .ForMember(dest => dest.IsBanned, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.IsVerified, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.StoreUsers, opt => opt.Ignore());

            CreateMap<ViewStoreVMResponse, Store>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.StoreName))
                .ForMember(dest => dest.IsBanned, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.IsVerified, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.StoreUsers, opt => opt.Ignore());

            CreateMap<Store, ViewStoreVMResponse>()
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Name));

            CreateMap<UpdateStoreVM, Store>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.StoreName));

            CreateMap<Store, ViewDetailStoreVMResponse>()
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Name));

        }
    }

}
*/