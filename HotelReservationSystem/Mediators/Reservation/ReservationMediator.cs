
using HotelReservationSystem.DTOs;
using HotelReservationSystem.DTOs.Rooms;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Services.Reservations;
using HotelReservationSystem.Services.RoomReservations;
using HotelReservationSystem.Services.Rooms;

namespace HotelReservationSystem.Mediators.Reservation
{
    public class ReservationMediator : IReservationMediator
    {
        private readonly IReservationService reservationService;
        private readonly IRoomService roomService;
        private readonly IRoomReservationService roomReservationService;


        public ReservationMediator(IReservationService _reservationService,IRoomService roomService, IRoomReservationService roomReservationService)
        {
            this.reservationService = _reservationService;
            this.roomService = roomService;
            this.roomReservationService = roomReservationService;
        }

        public void CancleReservation(ReservationDTO reservationDTO)
        {
            reservationDTO.Status = ReservationStatus.Cancelled;
            reservationService.UpdateReservation(reservationDTO);
        }

        //To be discussed 
        public List<RoomDTO> GetAvailableRooms()
        {
            var rooms = roomService.Get(r => !r.RoomReservations.Any());

            // throw new NotImplementedException();
            return rooms;

        }

        //To be discussed 
        public void MakeReservation(ReservationDTO reservationDTO)
        {
            int ReservtionId = reservationService.AddReservation(reservationDTO);
            List<RoomReservation> roomReservations = new List<RoomReservation>();

            foreach (var Room in reservationDTO.RoomDTOs)
            {
                roomReservations.Add(new RoomReservation { RoomId = Room.Id, ReservationId = ReservtionId });
            }
            roomReservationService.AddRange(roomReservations);
          
        }
    }
}
