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
            CreateMap<UpdateFacilityDto,FacilityViewModel>().ReverseMap();
            //CreateMap<UpdateFacilityDto,FacilityDTO>().ReverseMap();
            CreateMap<Facility,UpdateFacilityDto>().ReverseMap();

        }
    }
}
