using HotelReservationSystem.DTOs.Rooms;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Mediators.Rooms
{
    public interface IRoomMediator
    {
        //IEnumerable<RoomDTO> GetAvailableRooms();
        RoomDTO GetById(int id);
        Room AddRoom(CreateRoomDto roomDto);
        bool Update(UpdateRoomDto roomDto);
        bool Delete(int id);
        RoomDTO SearchRoom(int RoomNumber);
    }
}
