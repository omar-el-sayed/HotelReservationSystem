
using HotelReservationSystem.DTOs.Rooms;
using HotelReservationSystem.Models;
using System.Linq.Expressions;
using HotelReservationSystem.DTOs.Reservations;


namespace HotelReservationSystem.Services.Reservations
{
    public interface IReservationService
    {
       
        List<ReservationDTO> Get(Expression<Func<Reservation, bool>> predicate);
        int AddReservation(CreateResrvationDTO createResrvationDTO);
        void UpdateReservation(ReservationDTO reservationDTO);
        bool ValidateDate(DateTime CHeckIn, DateTime CheckOut);
        void UpdateReservationStatus(int ReservationId, ReservationStatus reservationStatus);
        List<int> GetReservedRooms(DateTime CheckIn, DateTime CheckOut);
        IEnumerable<ReservationDTO> GetReservations();
    }

}
