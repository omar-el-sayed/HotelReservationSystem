namespace HotelReservationSystem.Models
{
    public class RoomFacility : BaseEntity
    {
        public decimal Price { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        public int FacilitiesId { get; set; }
        public Facility? Facility { get; set; }
    }
}
