using HotelReservationSystem.DTOs.Room;

namespace HotelReservationSystem.Mediators.Room
{
    public interface IRoomMediator
    {
        //IEnumerable<RoomDTO> GetAvailableRooms();
        RoomDTO GetById(int id);
        void AddRoom(CreateRoomDto roomDto);
        bool Update(UpdateRoomDto roomDto);
        bool Delete(int id);
        RoomDTO SearchRoom(int RoomNumber);
    }
}
