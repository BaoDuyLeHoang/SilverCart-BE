using Application.Utils;
using AutoMapper;
using Application.ViewModels.UserViewModels;
using Domain.Entities;

namespace Infrastructures.Mappers
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            // Base User Mappings (Ánh xạ người dùng cơ bản)
            CreateMap<RegisterUserDTO, BaseUser>()
                .Include<RegisterUserDTO, CustomerUser>()
                .Include<RegisterUserDTO, StoreUser>()
                .Include<RegisterUserDTO, AdministratorUser>()
                .ForMember(dest => dest.IsVerified, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.SignInTime, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password.Hash()));
            // Specific User Type Mappings (Ánh xạ loại người dùng cụ thể)
            CreateMap<RegisterUserDTO, CustomerUser>();
            CreateMap<RegisterUserDTO, StoreUser>();
            CreateMap<RegisterUserDTO, AdministratorUser>();

            // Auth Response Mappings (Ánh xạ phản hồi xác thực)
            CreateMap<BaseUser, TokenResponseDTO>()
                .ForMember(dest => dest.AccessToken, opt => opt.Ignore())
                .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src => src.RefreshToken))
                .ForMember(dest => dest.Expiration, opt => opt.Ignore());

            // Login Mapping (Ánh xạ đăng nhập)
            CreateMap<LoginUserDTO, BaseUser>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            // User List Item Mapping (Ánh xạ mục danh sách người dùng)
            CreateMap<BaseUser, UserListItemDTO>()
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => DetermineUserType(src)))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.LastName} {src.FirstName}")); // It's a computed property
        }

        private string DetermineUserType(BaseUser user)
        {
            return user switch
            {
                AdministratorUser => "AdministratorUser",
                StoreUser => "StoreUser",
                CustomerUser => "CustomerUser",
                _ => "Unknown"
            };
        }
    }
}