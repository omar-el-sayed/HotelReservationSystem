namespace HotelReservationSystem.Models
{
    public class Offer : BaseEntity
    {
        public Offer() { 

            RoomOffers = new List<RoomOffer>();
        }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Discount { get; set; }
        public List<RoomOffer> RoomOffers { get; set; }
    }
}
