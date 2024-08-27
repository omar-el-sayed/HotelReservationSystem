using HotelReservationSystem.DTOs.Rooms;

namespace HotelReservationSystem.Mediators.Reservation
{
    public interface IReservationMediator
    {
        List<RoomDTO> GetAvailableRooms();
    }
}
