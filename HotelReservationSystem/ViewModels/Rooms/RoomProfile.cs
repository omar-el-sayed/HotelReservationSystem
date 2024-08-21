using AutoMapper;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.ViewModels.Rooms
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<RoomDTO, RoomViewModel>().ReverseMap();
            CreateMap<CreateRoomViewModel, CreateRoomDto>().ReverseMap();
            CreateMap<CreateRoomDto, Room>().ReverseMap();
            CreateMap<UpdateRoomViewModel, UpdateRoomDto>().ReverseMap();
            CreateMap<UpdateRoomDto, Room>().ReverseMap();
        }
    }
}
