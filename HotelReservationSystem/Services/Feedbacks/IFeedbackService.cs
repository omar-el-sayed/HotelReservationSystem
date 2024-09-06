using HotelReservationSystem.DTOs.Feedback;
using HotelReservationSystem.Models;
using System.Linq.Expressions;

namespace HotelReservationSystem.Services.Feedbacks
{
    public interface IFeedbackService
    {
        List<FeedBackDto> GetAll();
        List<FeedBackDto> Get(Expression<Func<FeedBack, bool>> predicate);
        FeedBackDto AddFeedback(FeedBackDto feedBackDto);
        bool UpdateFeedback(FeedBackDto feedBackDto);
        bool RemoveFeedback(int id);

    }
}
