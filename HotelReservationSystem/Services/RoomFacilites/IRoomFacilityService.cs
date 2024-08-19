using HotelReservationSystem.DTOs;

namespace HotelReservationSystem.Services.RoomFacilites
{
    public interface IRoomFacilityService
    {
        void AddRange(int id, IEnumerable<RoomFacilityDTO> roomFacilityDTOs);
    }
}
