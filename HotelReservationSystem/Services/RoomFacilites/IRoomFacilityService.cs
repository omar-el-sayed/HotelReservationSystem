using HotelReservationSystem.DTOs;

namespace HotelReservationSystem.Services.RoomFacilites
{
    public interface IRoomFacilityService
    {
        void AddRang(int id,IEnumerable<RoomFacilityDTO> roomFacilityDTOs);
    }
}
