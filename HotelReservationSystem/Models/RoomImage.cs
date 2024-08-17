using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Models
{
    public class RoomImage : BaseEntity
    {
        public string ImageURL { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }
        [ForeignKey("room")]
        public int? RoomId { get; set; }
        public  Room? room { get; set; }

    }
}
