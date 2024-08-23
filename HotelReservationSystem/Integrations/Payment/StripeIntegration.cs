using HotelReservationSystem.DTOs.Payment;
using Stripe;

namespace HotelReservationSystem.Integrations.Payment
{
    public class StripeIntegration : IStripeIntegration
    {
        public async Task<Charge> Charge(PaymentDto payment)
        {
            var chargeOptions = new ChargeCreateOptions
            {
                Amount = payment.Amount,
                Currency = payment.Currency,
                Source = "tok_visa",
                Description = payment.Description
            };

            var chargeService = new ChargeService();
            Charge charge = await chargeService.CreateAsync(chargeOptions);

            return charge;
        }

        public async Task<Invoice> CreateInvoice(PaymentDto payment)
        {
            var customer = await CreateCustomer(payment.Email, payment.Name);

            await CreateInvoiceItem(customer.Id, payment.Amount, payment.Currency, payment.Description);

            var invoice = await CreateAndFinalizeInvoice(customer.Id);

            return invoice;
        }

        #region Private Methods
        private async Task<Customer> CreateCustomer(string email, string name)
        {
            var options = new CustomerCreateOptions
            {
                Email = email,
                Name = name
            };
            var service = new CustomerService();
            return await service.CreateAsync(options);
        }

        private async Task CreateInvoiceItem(string customerId, long amount, string currency, string description)
        {
            var options = new InvoiceItemCreateOptions
            {
                Customer = customerId,
                Amount = amount,
                Currency = currency,
                Description = description,
            };
            var service = new InvoiceItemService();
            await service.CreateAsync(options);
        }

        private async Task<Invoice> CreateAndFinalizeInvoice(string customerId)
        {
            var invoiceOptions = new InvoiceCreateOptions
            {
                Customer = customerId,
                AutoAdvance = true, // Automatically finalize the invoice
            };
            var invoiceService = new InvoiceService();
            var invoice = await invoiceService.CreateAsync(invoiceOptions);

            // Optionally, send the invoice to the customer
            return await invoiceService.FinalizeInvoiceAsync(invoice.Id);
        }
        #endregion
    }
}
