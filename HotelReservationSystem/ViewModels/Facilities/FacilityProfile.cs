using AutoMapper;
using HotelReservationSystem.DTOs.Facility;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.ViewModels.Facilities
{
    public class FacilityProfile : Profile
    {
        public FacilityProfile()
        {
            CreateMap<Facility, FacilityDTO>().ReverseMap();
            CreateMap<FacilityDTO, FacilityViewModel>().ReverseMap();
        }
    }
}
