using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace HotelReservationSystem.Models
{
    public enum AvailableStatus
    {
        available, unavailable
    }

    public enum RoomType
    {
        Single, Double, Triple, suite
    }
    public class Room :BaseEntity
    {
        public Room()
        {
            roomImages = new List<RoomImage>();
            roomFacilities = new List<RoomFacility>();
            roomOffers = new List<RoomOffer>();
        }


        [Column(TypeName = "varchar(10)")]
        public RoomType RoomType { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int NumOfBed { get; set; }
        public int MaxOccupancy { get; set; }
        public double RoomSize { get; set; }
        [Column(TypeName = "varchar(20)")]
        public AvailableStatus AvailableStatus { get; set; }
        public int roomNumber { get; set; }
        public  List<RoomImage>? roomImages{ get; set; }
        public  List<RoomFacility>? roomFacilities { get; set; }
        public List<RoomOffer>? roomOffers { get; set; }

    }
}
