using HotelReservationSystem.DTOs;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.Feedbacks
{
    public class FeedbackService : IFeedbackService
    {
        private readonly GenericRepository<FeedBack> repo;

        public FeedbackService(GenericRepository<FeedBack> repo)
        {
                this.repo = repo;
        }
        public void Add(FeedBackDto feedBackDto)
        {
            FeedBack feedBack = feedBackDto.MapeOne<FeedBack>();
            repo.Add(feedBack);
          //  throw new NotImplementedException();
        }

    }
}
