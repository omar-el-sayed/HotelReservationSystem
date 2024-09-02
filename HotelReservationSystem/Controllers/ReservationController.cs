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
        [HttpGet]
        public ResultViewModel<IEnumerable<ReservationViewModel>> GetALlReservation()
        {
            var Reservation = reservationMediator.GetReservations().AsQueryable().Map<ReservationViewModel>();
            return ResultViewModel<IEnumerable<ReservationViewModel>>.Success(Reservation);
        }
        [HttpPost]
        public ResultViewModel<int> AddReservation(CreateReservationViewModel createReservationViewModel)
        {
            int ReservedId = reservationMediator.MakeReservation(createReservationViewModel.MapeOne<CreateResrvationDTO>());
            return ResultViewModel<int>.Success(ReservedId, $"Room is added successfully with id: {ReservedId}");
        }
    }
}
