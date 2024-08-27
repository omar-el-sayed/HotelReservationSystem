using HotelReservationSystem.DTOs;

namespace HotelReservationSystem.Services.RoomFacilites
{
    public interface IRoomFacilityService
    {
        void AddRange(int id, List<int> FacilitiesIDS);
    }
}
