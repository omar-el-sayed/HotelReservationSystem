using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Models;
using System.Linq.Expressions;

namespace HotelReservationSystem.Services.Rooms
{
    public interface IRoomService
    {
        RoomDTO GetById(int id);
        int Add(CreateRoomDto roomDTO);
        bool Update(UpdateRoomDto roomDto);
        bool Delete(int id);
        RoomDTO SearchRoom(int RoomNumber);
        public List<RoomDTO> Get(Expression<Func<Room, bool>> predicate);
    }
}
