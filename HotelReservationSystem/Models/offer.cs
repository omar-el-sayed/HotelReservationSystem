using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Models
{
    public class Offer : BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Discount { get; set; }
        public List<RoomOffer> RoomOffers { get; set; }


    }
}
