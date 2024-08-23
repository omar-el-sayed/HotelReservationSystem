using HotelReservationSystem.DTOs.Payment;
using Stripe;

namespace HotelReservationSystem.Integrations.Payment
{
    public interface IStripeIntegration
    {
        Task<Charge> Charge(PaymentDto payment);
        Task<Invoice> CreateInvoice(PaymentDto payment);
    }
}
