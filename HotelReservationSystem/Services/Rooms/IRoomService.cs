using HotelReservationSystem.DTOs.Room;

namespace HotelReservationSystem.Services.Rooms
{
    public interface IRoomService
    {
        IEnumerable<RoomDTO> GetAvailableRoom();
        RoomDTO GetById(int id);
        int Add(RoomDTO roomDTO);
        bool Update(UpdateRoomDto roomDto);
        bool Delete(int id);
    }
}
