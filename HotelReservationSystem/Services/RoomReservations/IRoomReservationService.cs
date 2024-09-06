using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services.RoomReservations
{
    public interface IRoomReservationService
    {
        void AddRange(int reservationID,List<int> roomIDs);
    }
}
