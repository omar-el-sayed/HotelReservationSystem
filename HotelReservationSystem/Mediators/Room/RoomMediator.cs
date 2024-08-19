using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Services.PictureRooms;
using HotelReservationSystem.Services.RoomFacilites;
using HotelReservationSystem.Services.Rooms;

namespace HotelReservationSystem.Mediators.Room
{

    public class RoomMediator : IRoomMediator
    {
        private readonly IRoomService roomService;
        private readonly IPictureRoomService pictureRoomService;
        private readonly IRoomFacilityService roomFacilityService;

        public RoomMediator(IRoomService roomService, IPictureRoomService pictureRoomService, IRoomFacilityService roomFacilityService)
        {
            this.roomService = roomService;
            this.pictureRoomService = pictureRoomService;
            this.roomFacilityService = roomFacilityService;
        }
        public void AddRoom(RoomDTO roomDto)
        {
            int roomid = roomService.Add(roomDto);
            // need to handle error if RoomPictures is null and RoomFacilities is null 
            pictureRoomService.AddRange(roomid, roomDto.RoomPictures);
            roomFacilityService.AddRange(roomid, roomDto.RoomFacilities);
        }
    }

}
