using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.Rooms
{
    public class RoomService(IGenericRepository<Room> repo) : IRoomService
    {
        public IEnumerable<RoomDTO> GetAvailableRooms()
        {
            var rooms = repo.Get(r => r.AvailableStatus == AvailableStatus.available);
            return rooms.Map<RoomDTO>();
        }

        public RoomDTO GetById(int id)
        {
            var room = repo.GetById(id);
            return room.MapeOne<RoomDTO>();
        }

        public int Add(CreateRoomDto roomDTO)
        {
            var room = roomDTO.MapeOne<Room>();
            repo.Add(room);
            repo.SaveChanges();

            return room.Id;
        }

        public bool Update(UpdateRoomDto roomDto)
        {
            var room = repo.GetByIdWithTracking(roomDto.Id);
            if (room is null)
                return false;

            var updatedRoom = roomDto.MapeOne<Room>();
            repo.Update(updatedRoom);
            repo.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var room = repo.GetByIdWithTracking(id);
            if (room is null)
                return false;

            repo.Delete(room);
            repo.SaveChanges();

            return true;
        }
    }
}
