using HotelReservationSystem.DTOs;

namespace HotelReservationSystem.Services.Rooms
{
    public interface IRoomService
    {
        IEnumerable<RoomDTO> GetAll();
        RoomDTO GetById(int id);
        RoomDTO Add(RoomDTO roomDTO);
    }
}
