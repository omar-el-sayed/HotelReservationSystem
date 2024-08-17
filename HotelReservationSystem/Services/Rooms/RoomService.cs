using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.Services.PictureRooms;

namespace HotelReservationSystem.Services.Rooms
{
    public class RoomService(IGenericRepository<Room> repo, IPictureRoomService pictureRoomService) : IRoomService
    {
        public RoomDTO Add(RoomDTO roomDTO)
        {
            var room = roomDTO.MapeOne<Room>();
            repo.Add(room);
            repo.SaveChanges();
            return roomDTO;
        }

        public bool Update(UpdateRoomDto roomDto)
        {
            var room = repo.GetByIdWithTracking(roomDto.Id);
            if (room is null)
                return false;

            //room.

            repo.Update(room);
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

        public IEnumerable<RoomDTO> GetAvailableRoom()
        {
            var rooms = repo.Get(r => r.AvailableStatus == AvailableStatus.available);
            //var rooms = repo.GetAll();
            return rooms.Map<RoomDTO>();
        }

        public RoomDTO GetById(int id)
        {
            var room = repo.GetById(id);
            return room.MapeOne<RoomDTO>();
        }
    }
}
