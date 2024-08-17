using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystem.Models
{
    public class RoomOffer : BaseEntity
    {
        [ForeignKey("room")]
        public int RoomId { get; set; }
        public Room? room { get; set; }
        [ForeignKey("offer")]
        public int offerId { get; set; }
        public offer? offer { get; set; }
    }
}
