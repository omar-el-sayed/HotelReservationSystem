using HotelReservationSystem.DTOs.Facility;
using HotelReservationSystem.DTOs.Room;

namespace HotelReservationSystem.DTOs
{
    public class RoomFacilityDTO
    {
        //public decimal Price { get; set; }
        public FacilityDTO Facility { get; set; }
        public RoomDTO Room { get; set; }

    }
}
