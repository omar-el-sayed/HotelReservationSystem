using HotelReservationSystem.DTOs.Payment;
using HotelReservationSystem.Integrations.Payment;
using Stripe;

namespace HotelReservationSystem.Mediators.Payment
{
    public class PaymentMediator(IStripeIntegration stripe) : IPaymentMediator
    {
        public async Task<Charge> Charge(PaymentDto payment)
            => await stripe.Charge(payment);

        public async Task<Invoice> CreateInvoice(PaymentDto payment)
            => await stripe.CreateInvoice(payment);
    }
}
