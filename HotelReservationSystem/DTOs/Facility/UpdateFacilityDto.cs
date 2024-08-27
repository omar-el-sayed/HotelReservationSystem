using HotelReservationSystem.Models;

namespace HotelReservationSystem.DTOs.Facility
{
    public class UpdateFacilityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
    }
}
