using HotelReservationSystem.DTOs.Room;
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
        public RoomService(IGenericRepository<Room> Repo, IPictureRoomService pictureRoomService)
        {
            Repo=repo;
            this.pictureRoomService=pictureRoomService;
        }
        public RoomDTO Add(RoomDTO roomDTO)
        {
            var room = roomDTO.MapeOne<Room>();
            repo.Add(room);
            repo.SaveChanges();
            pictureRoomService.AddRange(room.Id,roomDTO.RoomPictures);
            return roomDTO;
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

        public IEnumerable<RoomDTO> GetAvailableRoom()
        {
            var rooms = repo.Get(r => r.AvailableStatus == AvailableStatus.available);
            return rooms.Map<RoomDTO>();
        }

        public RoomDTO GetById(int id)
        {
            var room = repo.GetById(id);
            return room.MapeOne<RoomDTO>();
        }
    }
}
