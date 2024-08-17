using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Models
{
    public class Facility : BaseEntity
    {
        public Facility()
        {
            roomFacilities = new List<RoomFacility>();
        }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }

        public bool isAvailable { get; set; }
        public  List<RoomFacility>? roomFacilities { get; set; }

    }
}
