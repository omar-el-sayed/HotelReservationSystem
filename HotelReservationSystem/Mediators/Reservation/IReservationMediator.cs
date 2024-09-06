using HotelReservationSystem.DTOs.Reservations;
using HotelReservationSystem.DTOs.Rooms;

namespace HotelReservationSystem.Mediators.Reservation
{
    public interface IReservationMediator
    {
        List<RoomDTO> GetAvailableRooms(DateTime CheckIn, DateTime CheckOut);
        int MakeReservation(CreateResrvationDTO createResrvationDTO);
        void CancleReservation(int ReservationId);
        void ConfirmReservation(int ReservationId);

        IEnumerable<ReservationDTO> GetReservations();
    }
}
