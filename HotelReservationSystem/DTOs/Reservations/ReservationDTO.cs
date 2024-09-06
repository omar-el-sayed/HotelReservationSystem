using HotelReservationSystem.DTOs.Rooms;

namespace HotelReservationSystem.DTOs.Reservations
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public ReservationStatus Status { get; set; }
        public int NumOfGuests { get; set; }
        //public List<RoomDTO>? RoomDTOs { get; set; }
        public List<RoomReservationDTO>? roomReservationDTOs { get; set; }
    }
}
