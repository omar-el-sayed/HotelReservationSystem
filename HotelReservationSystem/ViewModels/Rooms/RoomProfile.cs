using AutoMapper;
using HotelReservationSystem.DTOs.Rooms;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.ViewModels.Rooms
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDTO>()
                .ForMember(dst => dst.RoomFacilities, opt => opt
                .MapFrom(src => src.RoomFacilities)).ReverseMap();

            CreateMap<RoomDTO, RoomViewModel>()
                .ForMember(dst => dst.RoomFacilities, opt => opt.MapFrom(src => src.RoomFacilities))
                .ForMember(dst => dst.AvailableStatus, opt => opt.MapFrom(src => src.AvailableStatus)).ReverseMap();

            CreateMap<CreateRoomViewModel, CreateRoomDto>().ReverseMap();
            CreateMap<CreateRoomDto, Room>().ReverseMap();
            CreateMap<UpdateRoomViewModel, UpdateRoomDto>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
        }
    }
}
