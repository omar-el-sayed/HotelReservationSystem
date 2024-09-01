using HotelReservationSystem.DTOs;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Services.Feedbacks
{
    public interface IFeedbackService
    {
        void Add(FeedBackDto feedBackDto);
    }
}
