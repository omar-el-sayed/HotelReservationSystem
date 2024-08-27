using HotelReservationSystem.DTOs.Facility;
using HotelReservationSystem.DTOs.Rooms;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services.Facilities
{
    public interface IFacilityService
    {
        IEnumerable<FacilityDTO> GetAvailableFacilities();
        Facility Add(FacilityDTO facilityDTO);
        bool Update(UpdateFacilityDto facilityDto);
        bool Delete(int id);

    }
}
