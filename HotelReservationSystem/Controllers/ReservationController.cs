using HotelReservationSystem.DTOs.Reservations;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Mediators.Reservation;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.Rservations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController(IReservationMediator reservationMediator) : ControllerBase
    {
        [HttpGet("GetALlReservation")]
        public ResultViewModel<IEnumerable<ReservationViewModel>> GetALlReservation()
        {
            var Reservation = reservationMediator.GetReservations().AsQueryable().Map<ReservationViewModel>();
            return ResultViewModel<IEnumerable<ReservationViewModel>>.Success(Reservation);
        }
        [HttpPost("AddReservation")]
        public ResultViewModel<int> AddReservation(CreateReservationViewModel createReservationViewModel)
        {
            int ReservedId = reservationMediator.MakeReservation(createReservationViewModel.MapeOne<CreateResrvationDTO>());
            return ResultViewModel<int>.Success(ReservedId, $"Reservation is done successfully with id: {ReservedId}");
        }
        [HttpPut("CancelReservation")]
        public ResultViewModel<int> CancelReservation(int reservationId)
        {
            reservationMediator.CancleReservation(reservationId);
            return ResultViewModel<int>.Success(reservationId, $"Reservation has been canceled successfully with id: {reservationId}");
        }

        [HttpPut("ConfirmReservation")]
        public ResultViewModel<int> ConfirmReservation(int reservationId)
        {
            reservationMediator.ConfirmReservation(reservationId);
            return ResultViewModel<int>.Success(reservationId, $"Reservation has been confirmed successfully with id: {reservationId}");
        }
    }
}
