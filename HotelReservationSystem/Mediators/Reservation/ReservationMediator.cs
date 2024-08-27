using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Services.Reservations;
using HotelReservationSystem.Services.Rooms;

namespace HotelReservationSystem.Mediators.Reservation
{
    public class ReservationMediator : IReservationMediator
    {
        private readonly IReservationService reservationService;
        public ReservationMediator(IReservationService _reservationService)
        {
            this.reservationService = _reservationService;
        }
        public List<RoomDTO> GetAvailableRooms(DateTime ReservationDate)
        {
           
           //var Rooms= reservationService.Get(r=>r.CheckinDate)
           throw new NotImplementedException();

        }
    }
}
