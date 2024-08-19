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

            if (roomDto.RoomPictures is not null && roomDto.RoomPictures.Count > 0)
                pictureRoomService.AddRange(roomid, roomDto.RoomPictures);

            if (roomDto.RoomFacilities is not null && roomDto.RoomFacilities.Count > 0)
                roomFacilityService.AddRange(roomid, roomDto.RoomFacilities);
        }
    }

}
