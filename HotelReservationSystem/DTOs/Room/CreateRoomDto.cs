namespace HotelReservationSystem.DTOs.Room
{
    public class CreateRoomDto
    {
        public RoomType RoomType { get; set; }
        public decimal Price { get; set; }
        public int NumOfBed { get; set; }
        public int MaxOccupancy { get; set; }
        public double RoomSize { get; set; }
        public AvailableStatus AvailableStatus { get; set; }
        public int RoomNumber { get; set; }
        public List<PictureRoomDTO>? RoomPictures { get; set; }
        public List<RoomFacilityDTO>? RoomFacilities { get; set; }
    }
}
