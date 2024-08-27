using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace HotelReservationSystem.Services.Rooms
{
    public class RoomService: IRoomService
    {
        public IGenericRepository<Room> repo { get; } 
        public RoomService(IGenericRepository<Room> repo)
        {
            this.repo = repo;
        }
        //public IEnumerable<RoomDTO> GetAvailableRooms()
        //{
        //    var rooms = repo.Get(r => r.AvailableStatus == AvailableStatus.available);
        //    return rooms.Map<RoomDTO>();
        //}

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
        public RoomDTO SearchRoom(int RoomNumber)
        {
            RoomDTO Room = repo.Get(r => r.RoomNumber == RoomNumber).MapeOne<RoomDTO>();
            return Room;
        }

        public List<RoomDTO> Get(Expression<Func<Room, bool>> predicate)
        {
            var Rooms = repo.Get(predicate).Map<RoomDTO>();
            return Rooms.ToList();
        }
    }
}
