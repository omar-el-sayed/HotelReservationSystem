using HotelReservationSystem.Models;

namespace HotelReservationSystem.DTOs
{
    public class RoomReservationDTO
    {
        public int RoomId { get; set; }
        public int ReservationId { get; set; }
        public Room? Room { get; set; }
        public Reservation? Reservation { get; set; }
    }
}
