namespace HotelReservationSystem.Models
{
    public class PictureRoom : BaseEntity
    {
        public string ImageURL { get; set; }
        public string Description { get; set; }
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
    }
}
