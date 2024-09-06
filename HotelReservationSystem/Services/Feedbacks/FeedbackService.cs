using HotelReservationSystem.DTOs.Feedback;
using HotelReservationSystem.Exceptions;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;
using System.Linq.Expressions;

namespace HotelReservationSystem.Services.Feedbacks
{
    public class FeedbackService : IFeedbackService
    {
        private readonly GenericRepository<FeedBack> repo;

        public FeedbackService(GenericRepository<FeedBack> repo)
        {
                this.repo = repo;
        }
        public FeedBackDto AddFeedback(FeedBackDto feedBackDto)
        {
            FeedBack feedBack = feedBackDto.MapeOne<FeedBack>();
            var AddedEntity = repo.Add(feedBack);
            repo.SaveChanges();
            return AddedEntity.MapeOne<FeedBackDto>();
        }

        public List<FeedBackDto> Get(Expression<Func<FeedBack, bool>> predicate)
        {
            var AllFeedbacks =  repo.Get(predicate).Map<FeedBackDto>();
            return AllFeedbacks.ToList();
        }

        public List<FeedBackDto> GetAll()
        {
            var AllFeedbacks = repo.GetAll().Map<FeedBackDto>();
            return AllFeedbacks.ToList();
        }

        public bool RemoveFeedback(int id)
        {
            var Feedback = repo.GetByIdWithTracking(id);
            if (Feedback != null)
            {
                repo.Delete(Feedback);
                repo.SaveChanges();
                return true;
            }
            else
            {
                throw new BusinessException(ErrorCode.DoesNotExist, $"FeedBack with id {id} not Exist");
            }
        }

        public bool UpdateFeedback (FeedBackDto feedBackDto)
        {
            var Feedback = repo.GetByIdWithTracking(feedBackDto.Id);
            if (Feedback != null)
            {
                feedBackDto.MapOne(Feedback);
                repo.SaveChanges();
                return true;
            }
            else
            {
                throw new BusinessException(ErrorCode.DoesNotExist, $"FeedBack with id {feedBackDto.Id} not Exist");
            }
        }
    }
}
