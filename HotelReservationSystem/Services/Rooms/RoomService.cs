using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;
using HotelReservationSystem.Services.PictureRooms;
using HotelReservationSystem.Services.RoomFacilites;

namespace HotelReservationSystem.Services.Rooms
{
    public class RoomService(IGenericRepository<Room> repo, IPictureRoomService pictureRoomService, IRoomFacilityService roomFacilityService) : IRoomService
    {
        public RoomDTO Add(RoomDTO roomDTO)
        {
            var room = roomDTO.MapeOne<Room>();
            repo.Add(room);
            repo.SaveChanges();
            // need to handle error if RoomPictures is null and RoomFacilities is null 
            pictureRoomService.AddRange(room.Id, roomDTO.RoomPictures);
            roomFacilityService.AddRang(room.Id, roomDTO.RoomFacilities);
            return room.MapeOne<RoomDTO>();
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
