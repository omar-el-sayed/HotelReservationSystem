namespace HotelReservationSystem.Models
{
    public class Room : BaseEntity
    {
        public Room()
        {
            RoomPictures = new List<PictureRoom>();
            RoomFacilities = new List<RoomFacility>();
            RoomOffers = new List<RoomOffer>();
            Reservations = new List<Reservation>();
        }

        public RoomType RoomType { get; set; }
        public decimal Price { get; set; }
        public int NumOfBed { get; set; }
        public int MaxOccupancy { get; set; }
        public double RoomSize { get; set; }
        public int RoomNumber { get; set; }
        public List<PictureRoom>? RoomPictures { get; set; }
        public List<RoomFacility>? RoomFacilities { get; set; }
        public List<RoomOffer>? RoomOffers { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
