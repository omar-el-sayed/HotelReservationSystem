namespace HotelReservationSystem.Models
{
    public class RoomReservation :BaseEntity
    {
        public int RoomId { get; set; }
        public int ReservationId { get; set; }
        public Room? Room { get; set; }
        public Reservation? Reservation { get; set; }
        //public List<RoomReservation>? RoomReservations   { get; set; }
    }
}
