using AutoMapper;
using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomDTO>().ReverseMap();
        }
    }
}
