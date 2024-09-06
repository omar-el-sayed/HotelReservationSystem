using HotelReservationSystem.DTOs;
using HotelReservationSystem.DTOs.Rooms;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels.RoomReservations;

namespace HotelReservationSystem.ViewModels.Rservations
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public ReservationStatus Status { get; set; }
        public int NumOfGuests { get; set; }
        //public List<RoomDTO>? RoomDTOs { get; set; }
        public List<RoomReservationViewModel>? RoomReservationsVM { get; set; }
    }
}
