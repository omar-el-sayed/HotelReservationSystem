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
                .ForMember(dst=>dst.roomReservationDTOs,opt=>opt.MapFrom(src=>src.RoomReservations)).ReverseMap();

            CreateMap<ReservationDTO,Reservation>()
                .ForMember(dst=>dst.RoomReservations,opt=>opt.MapFrom(src=>src.roomReservationDTOs)).ReverseMap();

            CreateMap<CreateResrvationDTO, Reservation>().ReverseMap();


            CreateMap<CreateReservationViewModel,CreateResrvationDTO>()
               .ForMember(dst=>dst.RoomIds,opt=>opt.MapFrom(src=>src.RoomIds)).ReverseMap();
        }
    }
}
