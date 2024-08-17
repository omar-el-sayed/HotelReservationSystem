using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Models
{
    public class Facility : BaseEntity
    {
        public Facility()
        {
            RoomFacilities = new List<RoomFacility>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsAvailable { get; set; }
        public  List<RoomFacility>? RoomFacilities { get; set; }

    }
}
