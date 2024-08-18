using HotelReservationSystem.DTOs.Room;

namespace HotelReservationSystem.Mediators.Room
{
    public interface IRoomMediator
    {
        void AddRoom(CreateRoomDto roomDto);
    }
}
