using HotelReservationSystem.DTOs.Room;

namespace HotelReservationSystem.Services.Reservations
{
    public interface IReservationService
    {
        IEnumerable<RoomDTO> GetUnReservedRooms();
    }
}
