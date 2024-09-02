using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services.RoomReservations
{
    public interface IRoomReservationService
    {
        void AddRange(List<RoomReservation> roomReservations);
    }
}
