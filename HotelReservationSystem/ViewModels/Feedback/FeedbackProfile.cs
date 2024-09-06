using AutoMapper;
using HotelReservationSystem.DTOs.Feedback;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.ViewModels.Feedback
{
    public class FeedbackProfile:Profile
    {
        public FeedbackProfile()
        {
            CreateMap<FeedBack,FeedBackDto>().ReverseMap();
            CreateMap<FeedBackDto,FeedbackViewModel>().ReverseMap();
        }
    }
}
