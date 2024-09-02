using AutoMapper;
using HotelReservationSystem.DTOs.Reservations;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.ViewModels.Rservations
{
    public class ReservationProfile:Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationViewModel, ReservationDTO>()
                .ForMember(dst=>dst.Id,opt=>opt.Ignore())
                .ForMember(dst=>dst.RoomDTOs,opt=>opt.MapFrom(src=>src.RoomDTOs)).ReverseMap();

            CreateMap<ReservationDTO,Reservation>()
                .ForMember(dst=>dst.Rooms,opt=>opt.MapFrom(src=>src.RoomDTOs)).ReverseMap();

            CreateMap<CreateReservationViewModel,CreateResrvationDTO>().ReverseMap();
        }
    }
}
