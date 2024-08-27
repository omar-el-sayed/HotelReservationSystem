using HotelReservationSystem.ViewModels.PictureRooms;
using HotelReservationSystem.ViewModels.RoomFailites;

namespace HotelReservationSystem.ViewModels.Rooms
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public RoomType RoomType { get; set; }
        public decimal Price { get; set; }
        public int NumOfBed { get; set; }
        public int MaxOccupancy { get; set; }
        public double RoomSize { get; set; }
        public string AvailableStatus { get; set; }
        public int RoomNumber { get; set; }
        public List<PictureRoomViewModel>? RoomPictures { get; set; }
        public List<RoomFacilityViewModel>? RoomFacilities { get; set; }
    }
}
