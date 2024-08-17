using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystem.Models
{
    public class RoomFacility :BaseEntity
    {
        public decimal Price { get; set; }
        [ForeignKey("room")]
        public int RoomId { get; set; }
        public  Room? room { get; set; }
        [ForeignKey("Facility")]
        public int FacilitiesId { get; set; }
        public  Facility? Facility { get; set; }
    }
}
