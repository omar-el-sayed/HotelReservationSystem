using HotelReservationSystem.DTOs.Rooms;

namespace HotelReservationSystem.ViewModels.Rservations
{
    public class CreateReservationViewModel
    {
        //public int Id { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int NumOfGuests { get; set; }
        public List<RoomDTO>? RoomDTOs { get; set; }
    }
}
