using HotelReservationSystem.DTOs.Rooms;
using HotelReservationSystem.Exceptions;
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
            //var room = repo.GetById(id);
            var room =repo.Get(x=>x.Id == id);
            return room.Map<RoomDTO>().FirstOrDefault();
        }

        public Room Add(CreateRoomDto roomDTO)
        {
            var room = roomDTO.MapeOne<Room>();
            repo.Add(room);
            repo.SaveChanges();

            return room;
        }

        public bool Update(UpdateRoomDto roomDto)
        {
            var room = repo.GetByIdWithTracking(roomDto.Id);
            if (room is null)
                throw new BusinessException(ErrorCode.DoesNotExist, $"Room with id {room.Id} Not Exist ");

            roomDto.MapOne(room);
            repo.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var room = repo.GetByIdWithTracking(id);
            if (room is null)
                throw new BusinessException(ErrorCode.DoesNotExist, $"Room with id {id} Not Exist ");


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
