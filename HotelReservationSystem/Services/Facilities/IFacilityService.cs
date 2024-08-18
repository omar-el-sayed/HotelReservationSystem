using HotelReservationSystem.DTOs;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services.Facilities
{
    public interface IFacilityService
    {
        bool ValidateFacilityExisiting(string name);
        Facility Add(FacilityDTO facilityDTO);

    }
}
