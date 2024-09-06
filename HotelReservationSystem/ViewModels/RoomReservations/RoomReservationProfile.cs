using AutoMapper;
using HotelReservationSystem.DTOs;
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
                .ForMember(dist=>dist.RoomId,opt=>opt.MapFrom(src=>src.roomReservationDTOs.Select(r=>r.RoomId))).ReverseMap();

            CreateMap<RoomReservationDTO, RoomReservation>().ReverseMap();
            CreateMap<RoomReservationDTO, RoomReservationViewModel>().ReverseMap();

        }
    }
}
