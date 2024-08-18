using HotelReservationSystem.Models;

namespace HotelReservationSystem.DTOs
{
    public class FacilityDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        //public List<RoomFacility>? RoomFacilities { get; set; }
    }
}
