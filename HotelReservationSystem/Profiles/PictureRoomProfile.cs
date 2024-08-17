using AutoMapper;
using HotelReservationSystem.DTOs;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Profiles
{
    public class PictureRoomProfile :Profile
    {
        public PictureRoomProfile()
        {
            CreateMap<PictureRoom,PictureRoomDTO>().ReverseMap()
                .ForMember(dst=>dst.RoomId,opt=>opt.Ignore());
        }
    }
}
