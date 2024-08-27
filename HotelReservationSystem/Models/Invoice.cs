namespace HotelReservationSystem.Models
{
    public class Invoice:BaseEntity
    {
        public Invoice()
        {
            Reservations = new List<Reservation>();
        }
        public DateTime InvoiceDate { get; set; }   
        public decimal InvoiceAmount { get; set; }
        public int? ReservationID { get; set; } 
        public List<Reservation>? Reservations { get; set; }
    }
}
