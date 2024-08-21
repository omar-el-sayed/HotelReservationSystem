using HotelReservationSystem.DTOs.Room;

namespace HotelReservationSystem.Services.Rooms
{
    public interface IRoomService
    {
        IEnumerable<RoomDTO> GetAvailableRooms();
        RoomDTO GetById(int id);
        int Add(CreateRoomDto roomDTO);
        bool Update(UpdateRoomDto roomDto);
        bool Delete(int id);
    }
}
