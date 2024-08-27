using HotelReservationSystem.DTOs.Rooms;
using HotelReservationSystem.Models;
using HotelReservationSystem.Services.PictureRooms;
using HotelReservationSystem.Services.RoomFacilites;
using HotelReservationSystem.Services.Rooms;
using Microsoft.Identity.Client;

namespace HotelReservationSystem.Mediators.Rooms
{

    public class RoomMediator : IRoomMediator
    {
        private readonly IRoomService roomService;
        private readonly IPictureRoomService pictureRoomService;
        private readonly IRoomFacilityService roomFacilityService;

        public RoomMediator(IRoomService roomService, IPictureRoomService pictureRoomService, IRoomFacilityService roomFacilityService) {
            this.roomService = roomService;
            this.pictureRoomService = pictureRoomService;
            this.roomFacilityService = roomFacilityService;
        }

        //public IEnumerable<RoomDTO> GetAvailableRooms()
        //    => roomService.GetAvailableRooms();

        public RoomDTO GetById(int id)
            => roomService.GetById(id);

        public Room AddRoom(CreateRoomDto roomDto)
        {
            var room = roomService.Add(roomDto);

            if (roomDto.RoomPictures is not null && roomDto.RoomPictures.Count > 0)
                pictureRoomService.AddRange(room.Id, roomDto.RoomPictures);

            if (roomDto.FacilitiesIDS is not null && roomDto.FacilitiesIDS.Count > 0)
                roomFacilityService.AddRange(room.Id, roomDto.FacilitiesIDS);

            return room;
        }
        public bool Update(UpdateRoomDto roomDto)
            => roomService.Update(roomDto);

        public bool Delete(int id)
            => roomService.Delete(id);

        public RoomDTO SearchRoom(int RoomNumber)
            =>roomService.SearchRoom(RoomNumber);
    }

}
