using HotelReservationSystem.DTOs.Payment;
using Stripe;

namespace HotelReservationSystem.Mediators.Payment
{
    public interface IPaymentMediator
    {
        Task<Charge> Charge(PaymentDto payment);
        Task<Invoice> CreateInvoice(PaymentDto payment);
    }
}
