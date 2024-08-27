using Stripe;
using System.Collections.ObjectModel;

namespace HotelReservationSystem.Models
{
    public class Reservation:BaseEntity
    {
        public Reservation()
        {
            Rooms = new List<Room>();
        }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public decimal TotalPrice {  get; set; }
        public ReservationStatus Status { get; set; }
        public int NumOfGuests { get; set; }
        public List<Room>? Rooms { get; set; }

      //  public int? CustomerId { get; set; }
       // public Customer? Customer { get; set; }
        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }
        public int? InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }

    }
}
