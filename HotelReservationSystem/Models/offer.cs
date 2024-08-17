using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Models
{
    public class offer : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public decimal discount { get; set; }
        public List<RoomOffer> roomOffers { get; set; }


    }
}
