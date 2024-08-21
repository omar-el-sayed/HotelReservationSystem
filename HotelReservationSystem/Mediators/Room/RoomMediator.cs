using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Services.PictureRooms;
using HotelReservationSystem.Services.RoomFacilites;
using HotelReservationSystem.Services.Rooms;

namespace HotelReservationSystem.Mediators.Room
{

    public class RoomMediator(IRoomService roomService, IPictureRoomService pictureRoomService, IRoomFacilityService roomFacilityService) : IRoomMediator
    {
        public IEnumerable<RoomDTO> GetAvailableRooms()
            => roomService.GetAvailableRooms();

        public RoomDTO GetById(int id)
            => roomService.GetById(id);

        public void AddRoom(CreateRoomDto roomDto)
        {
            int roomid = roomService.Add(roomDto);

            if (roomDto.RoomPictures is not null && roomDto.RoomPictures.Count > 0)
                pictureRoomService.AddRange(roomid, roomDto.RoomPictures);

            if (roomDto.RoomFacilities is not null && roomDto.RoomFacilities.Count > 0)
                roomFacilityService.AddRange(roomid, roomDto.RoomFacilities);
        }

        public bool Update(UpdateRoomDto roomDto)
            => roomService.Update(roomDto);

        public bool Delete(int id)
            => roomService.Delete(id);
    }

}
