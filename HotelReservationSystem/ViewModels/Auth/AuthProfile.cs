using AutoMapper;
using HotelReservationSystem.DTOs.Auth;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.ViewModels.Auth
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<AuthViewModel, AuthDto>().ReverseMap();
            CreateMap<RegisterViewModel, RegisterDto>().ReverseMap();
            CreateMap<RegisterDto, User>().ReverseMap();
            CreateMap<TokenRequestViewModel, TokenRequestDto>().ReverseMap();
            CreateMap<AddRoleViewModel, AddRoleDto>().ReverseMap();
        }
    }
}
