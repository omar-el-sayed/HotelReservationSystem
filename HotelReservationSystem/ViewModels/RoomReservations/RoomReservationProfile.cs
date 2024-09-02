using AutoMapper;
using HotelReservationSystem.DTOs.Reservations;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.ViewModels.RoomReservations
{
    public class RoomReservationProfile : Profile
    {
        public RoomReservationProfile()
        {
            CreateMap<ReservationDTO, RoomReservation>()
                .ForMember(dist=>dist.ReservationId,opt=>opt.MapFrom(src=>src.Id))
                .ForMember(dist=>dist.RoomId,opt=>opt.MapFrom(src=>src.RoomDTOs.Select(r=>r.Id))).ReverseMap();
        }
    }
}
