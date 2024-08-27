using HotelReservationSystem.DTOs.Rooms;

namespace HotelReservationSystem.Services.Reservations
{
    public interface IReservationService
    {
        IEnumerable<RoomDTO> GetUnReservedRooms();
    }
}
