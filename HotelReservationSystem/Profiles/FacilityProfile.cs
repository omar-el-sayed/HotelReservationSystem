using AutoMapper;
using HotelReservationSystem.DTOs;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Profiles
{
    public class FacilityProfile :Profile
    {
        public FacilityProfile()
        {
            CreateMap<Facility, FacilityDTO>().ReverseMap();
        }
    }
}
