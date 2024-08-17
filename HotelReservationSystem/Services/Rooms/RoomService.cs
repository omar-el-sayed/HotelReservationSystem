using HotelReservationSystem.DTOs;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.Services.PictureRooms;

namespace HotelReservationSystem.Services.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly IGenericRepository<Room> repo;
        private readonly IPictureRoomService pictureRoomService;

        public RoomService(IGenericRepository<Room> Repo,IPictureRoomService pictureRoomService)
        {
            repo = Repo;
            this.pictureRoomService = pictureRoomService;
        }

        public RoomDTO Add(RoomDTO roomDTO)
        {
            var room =roomDTO.MapeOne<Room>();
            repo.Add(room);
            repo.SaveChanges();
            return roomDTO;
        }

        public IEnumerable<RoomDTO> GetAvailableRoom()
        {
            var rooms = repo.Get(r => r.AvailableStatus == AvailableStatus.available);
            return rooms.Map<RoomDTO>();
        }

        public RoomDTO GetById(int id)
        {
            var room=repo.GetById(id);
            return room.MapeOne<RoomDTO>();
        }
    }
}
