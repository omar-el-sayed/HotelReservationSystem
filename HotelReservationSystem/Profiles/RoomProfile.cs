using AutoMapper;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels.Room;

namespace HotelReservationSystem.Profiles
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
