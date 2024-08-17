using HotelReservationSystem.DTOs;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly IGenericRepository<Room> repo;

        public RoomService(IGenericRepository<Room> Repo)
        {
            repo = Repo;
        }

        public RoomDTO Add(RoomDTO roomDTO)
        {
            return null;
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
