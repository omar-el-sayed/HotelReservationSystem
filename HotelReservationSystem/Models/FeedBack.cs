using Stripe;

namespace HotelReservationSystem.Models
{
    public class FeedBack:BaseEntity
    {
        public decimal ? Rate { get; set; }
        public string Comment { get; set; }
        public DateTime SubmittedDate { get; set; }
        public string StaffResponse { get; set; }
        public DateTime ResponceDate { get; set; }

      //  public int? CustomerId { get; set; }
       // public Customer? Customer { get; set; }
    }
}
