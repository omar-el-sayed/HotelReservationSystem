namespace HotelReservationSystem.ViewModels.Payments
{
    public class PaymentViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public long Amount { get; set; } // amount in cents
        public string Currency { get; set; } = "egp";
        public string Description { get; set; }
    }
}
