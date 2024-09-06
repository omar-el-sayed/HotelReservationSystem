using HotelReservationSystem.DTOs.Feedback;
using HotelReservationSystem.DTOs.Rooms;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Mediators.Rooms;
using HotelReservationSystem.Services.Feedbacks;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.Feedback;
using HotelReservationSystem.ViewModels.Rooms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        [HttpGet("GetAllFeedbacks")]
        public ResultViewModel<IEnumerable<FeedbackViewModel>> GetAllFeedbacks()
        {
            var Feedbacks = feedbackService.GetAll().AsQueryable().Map<FeedbackViewModel>();
            return  ResultViewModel<IEnumerable<FeedbackViewModel>>.Success(Feedbacks);
        }

        [HttpPost("AddFeedback")]
        public ResultViewModel<int> AddFeedback (FeedbackViewModel feedbackViewModel)
        {
            var AddedEntity = feedbackService.AddFeedback(feedbackViewModel.MapeOne<FeedBackDto>());
            return ResultViewModel<int>.Success(AddedEntity.Id,$"Feedback Added Successfully!");
        }

        [HttpPut("Edit")]
        public ResultViewModel<int> UpdateFeedback(FeedbackViewModel feedbackViewModel)
        {
            if (feedbackService.UpdateFeedback(feedbackViewModel.MapeOne<FeedBackDto>()))
                return ResultViewModel<int>.Success(feedbackViewModel.Id, $"feedback with id: {feedbackViewModel.Id} is updated successfully");
            else
                return ResultViewModel<int>.Failure(ErrorCode.FailedUpdateRoom, $"Failed to update feedack with id: {feedbackViewModel.Id}");
        }

        [HttpDelete("delete/{id}")]
        public ResultViewModel<int> DeleteFeedback(int id)
        {
            if (feedbackService.RemoveFeedback(id))
            {
                return ResultViewModel<int>.Success(id, $"feedback with id: {id} is deleted successfully");
            }
            else 
            {
                return ResultViewModel<int>.Failure(ErrorCode.FailedDeleteRoom, $"There's an error occured while deleting feedback with id: {id}");
            }
        }

    }
}
