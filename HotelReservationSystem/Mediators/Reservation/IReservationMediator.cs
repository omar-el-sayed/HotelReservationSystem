using HotelReservationSystem.DTOs;
using HotelReservationSystem.DTOs.Rooms;

namespace HotelReservationSystem.Mediators.Reservation
{
    public interface IReservationMediator
    {
        List<RoomDTO> GetAvailableRooms();
        void MakeReservation(ReservationDTO reservationDTO);
        void CancleReservation(ReservationDTO reservationDTO);
    }
}
