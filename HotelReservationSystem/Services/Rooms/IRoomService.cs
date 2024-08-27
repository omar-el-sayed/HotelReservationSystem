using HotelReservationSystem.DTOs.Rooms;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services.Rooms
{
    public interface IRoomService
    {
        //IEnumerable<RoomDTO> GetAvailableRooms();
        RoomDTO GetById(int id);
        Room Add(CreateRoomDto roomDTO);
        bool Update(UpdateRoomDto roomDto);
        bool Delete(int id);
        RoomDTO SearchRoom(int RoomNumber);
    }
}
