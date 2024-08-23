using AutoMapper;
using HotelReservationSystem.DTOs.Payment;
using HotelReservationSystem.ViewModels.Payment;
using Stripe;

namespace HotelReservationSystem.ViewModels.Payments
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentViewModel, PaymentDto>().ReverseMap();
            CreateMap<Charge, ChargeViewModel>().ReverseMap();
            //CreateMap<PaymentDto, Payment>().ReverseMap();
        }
    }
}
