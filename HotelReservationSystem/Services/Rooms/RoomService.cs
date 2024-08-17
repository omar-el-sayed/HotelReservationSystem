using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.Rooms
{
    public class RoomService(IGenericRepository<Room> repo) : IRoomService
    {
        public RoomDTO Add(RoomDTO roomDTO)
        {
            return null;
        }

        public bool Update(UpdateRoomDto roomDto)
        {
            var room = repo.GetByIdWithTracking(roomDto.Id);

            if (room is null)
                return false;

            //room.

            repo.Update(room);
            return true;
        }

        public bool Delete(int id)
        {
            var room = repo.GetByIdWithTracking(id);

            if (room is null)
                return false;

            repo.Delete(room);
            return true;
        }

        public IEnumerable<RoomDTO> GetAll()
        {
            var rooms = repo.GetAll();
            return rooms.Map<RoomDTO>();
        }

        public RoomDTO GetById(int id)
        {
            var room = repo.GetById(id);
            return room.MapeOne<RoomDTO>();
        }
    }
}
