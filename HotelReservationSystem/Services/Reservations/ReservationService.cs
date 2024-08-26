using HotelReservationSystem.DTOs.Room;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly IGenericRepository<Reservation> repo;

        public ReservationService(IGenericRepository<Reservation> repo)
        {
            this.repo = repo;
        }
        public IEnumerable<RoomDTO> GetUnReservedRooms()
        {
            DateTime TimeNow = DateTime.Now;
            var Rooms=repo.Get(r=>r.CheckoutDate<TimeNow && r.Status==ReservationStatus.Available).AsQueryable().Map<RoomDTO>();
            return Rooms;
        }
        public void SetAVailableStatusRoom()
        {

        }
    }
}
