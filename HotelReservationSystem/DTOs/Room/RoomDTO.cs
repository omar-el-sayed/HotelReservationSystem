using HotelReservationSystem.Models;

namespace HotelReservationSystem.DTOs.Room
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public RoomType RoomType { get; set; }
        public decimal Price { get; set; }
        public int NumOfBed { get; set; }
        public int MaxOccupancy { get; set; }
        public double RoomSize { get; set; }
        public AvailableStatus AvailableStatus { get; set; }
        public int RoomNumber { get; set; }
        public List<PictureRoom>? RoomPictures { get; set; }
        public List<RoomFacility>? RoomFacilities { get; set; }
        public List<RoomOffer>? RoomOffers { get; set; }
    }
}
