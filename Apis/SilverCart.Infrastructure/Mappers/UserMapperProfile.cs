using SilverCart.Application.Utils;
using AutoMapper;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures.Mappers
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            // Base User Mappings (Ánh xạ người dùng cơ bản)
            //CreateMap<RegisterUserDTO, BaseUser>()
            //    .Include<RegisterUserDTO, CustomerUser>()
            //    .Include<RegisterUserDTO, AdministratorUser>()
            //    .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password.Hash()));
            //// Specific User Type Mappings (Ánh xạ loại người dùng cụ thể)
            //CreateMap<RegisterUserDTO, CustomerUser>();
            //CreateMap<RegisterUserDTO, StoreUser>();
            //CreateMap<RegisterUserDTO, AdministratorUser>();

            //// Login Mapping (Ánh xạ đăng nhập)
            //CreateMap<LoginUserDTO, BaseUser>()
            //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //    .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            // User List Item Mapping (Ánh xạ mục danh sách người dùng)
        }

        //private string DetermineUserType(BaseUser user)
        //{
        //    return user switch
        //    {
        //        AdministratorUser => "AdministratorUser",
        //        CustomerUser => "CustomerUser",
        //        _ => "Unknown"
        //    };
        //}
    }
}