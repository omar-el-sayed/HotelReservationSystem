using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Services.PictureRooms;
using HotelReservationSystem.Services.Rooms;

namespace HotelReservationSystem.Mediators.Room
{
    public class RoomMediator(IRoomService roomService, IPictureRoomService pictureRoomService) : IRoomMediator
    {
        public void AddRoom(CreateRoomDto roomDto)
        {
            //roomService.Add();

            //pictureRoomService.AddRange();


        }
    }
}
