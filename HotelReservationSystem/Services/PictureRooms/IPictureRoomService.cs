using HotelReservationSystem.DTOs;

namespace HotelReservationSystem.Services.PictureRooms
{
    public interface IPictureRoomService
    {
        void AddRange(int Id, IEnumerable<PictureRoomDTO> pictureRoomDTO);
    }
}
