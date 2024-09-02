using HotelReservationSystem.DTOs.Rooms;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.ViewModels.Rservations
{
    public class ReservationViewModel
    {
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public ReservationStatus Status { get; set; }
        public int NumOfGuests { get; set; }
        public List<RoomDTO>? RoomDTOs { get; set; }
        //public List<RoomReservation>? RoomReservations { get; set; }
    }
}
