using AutoMapper;
using HotelReservationSystem.DTOs;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Profiles
{
    public class RoomProfile:Profile
    {
        public RoomProfile()
        {
            CreateMap<Room,RoomDTO>().ReverseMap();
        }
    }
}
