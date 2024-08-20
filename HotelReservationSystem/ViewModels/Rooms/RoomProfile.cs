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
            CreateMap<CreateRoomViewModel, RoomDTO>().ReverseMap();
            CreateMap<UpdateRoomViewModel, UpdateRoomDto>().ReverseMap();
        }
    }
}
