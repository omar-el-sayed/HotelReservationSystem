namespace HotelReservationSystem.Models
{
    public class Payment : BaseEntity
    {
        public string CardNumber { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string Cvc { get; set; }
        public long Amount { get; set; }  // amount in cents
        public string Currency { get; set; } = "egp";
        //public int MyProperty { get; set; }
    }
}
