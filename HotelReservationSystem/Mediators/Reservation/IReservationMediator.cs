using HotelReservationSystem.DTOs.Room;

namespace HotelReservationSystem.Mediators.Reservation
{
    public interface IReservationMediator
    {
        List<RoomDTO> GetAvailableRooms(DateTime ReservationDate);

    }
}
