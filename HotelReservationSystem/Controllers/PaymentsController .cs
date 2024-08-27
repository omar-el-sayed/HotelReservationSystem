using HotelReservationSystem.DTOs.Payment;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Mediators.Payment;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.Payment;
using HotelReservationSystem.ViewModels.Payments;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(IPaymentMediator paymentMediator) : BaseController
    {
        [HttpPost("charge")]
        public async Task<ResultViewModel<ChargeViewModel>> ChargeAsync([FromBody] PaymentViewModel payment)
        {
            try
            {
                var charge = await paymentMediator.Charge(payment.MapeOne<PaymentDto>());

                var chargeVM = charge.MapeOne<ChargeViewModel>();

                return ResultViewModel<ChargeViewModel>.Success(chargeVM, "Payment charged successfully");
            }
            catch (StripeException ex)
            {
                return ResultViewModel<ChargeViewModel>.Failure(ErrorCode.PaymentFailure, ex.StripeError.Message);
            }
        }

        [HttpPost("create-invoice")]
        public async Task<ResultViewModel<InvoiceViewModel>> CreateInvoiceAsync([FromBody] PaymentViewModel payment)
        {
            var invoice = await paymentMediator.CreateInvoice(payment.MapeOne<PaymentDto>());

            var invoiceVM = invoice.MapeOne<InvoiceViewModel>();

            return ResultViewModel<InvoiceViewModel>.Success(invoiceVM, "Invoice created successfully");
        }
    }
}
