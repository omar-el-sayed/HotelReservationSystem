namespace HotelReservationSystem.Models
{
    public class RoomOffer : BaseEntity
    {
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        public int OfferId { get; set; }
        public Offer? Offer { get; set; }
    }
}
