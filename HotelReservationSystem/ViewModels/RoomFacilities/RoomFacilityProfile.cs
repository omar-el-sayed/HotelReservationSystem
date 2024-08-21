using AutoMapper;
using HotelReservationSystem.DTOs;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.ViewModels.RoomFailites
{
    public class RoomFacilityProfile : Profile
    {
        public RoomFacilityProfile()
        {
            CreateMap<RoomFacility, RoomFacilityDTO>().ReverseMap();
            CreateMap<RoomFacilityDTO, RoomFacilityViewModel>().ReverseMap();
        }
    }
}
