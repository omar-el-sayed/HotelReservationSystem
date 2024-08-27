namespace HotelReservationSystem.Models
{
    public class RoomReservation
    {
        public int RoomId { get; set; }
        public int ReservatioinId { get; set; }
        public Room? Room { get; set; }
        public List<RoomReservation>? RoomReservations   { get; set; }
    }
}
