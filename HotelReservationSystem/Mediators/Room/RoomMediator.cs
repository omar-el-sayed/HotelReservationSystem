using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Services.PictureRooms;
using HotelReservationSystem.Services.RoomFacilites;
using HotelReservationSystem.Services.Rooms;
using Microsoft.Identity.Client;

namespace HotelReservationSystem.Mediators.Room
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

        public void AddRoom(CreateRoomDto roomDto)
        {
            int roomid = roomService.Add(roomDto);

            if (roomDto.RoomPictures is not null && roomDto.RoomPictures.Count > 0)
                pictureRoomService.AddRange(roomid, roomDto.RoomPictures);

            //if (roomDto.RoomFacilities is not null && roomDto.RoomFacilities.Count > 0)
            //    roomFacilityService.AddRange(roomid, roomDto.RoomFacilities);

            if (roomDto.FacilitiesIDS is not null && roomDto.FacilitiesIDS.Count > 0)
                roomFacilityService.AddRange(roomid, roomDto.FacilitiesIDS);


        }
        public bool Update(UpdateRoomDto roomDto)
            => roomService.Update(roomDto);

        public bool Delete(int id)
            => roomService.Delete(id);

        public RoomDTO SearchRoom(int RoomNumber)
            =>roomService.SearchRoom(RoomNumber);
    }

}
