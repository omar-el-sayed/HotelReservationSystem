using HotelReservationSystem.DTOs.Reservations;
using HotelReservationSystem.DTOs.Rooms;
using HotelReservationSystem.Exceptions;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Services.Reservations;
using HotelReservationSystem.Services.RoomReservations;
using HotelReservationSystem.Services.Rooms;
using Microsoft.EntityFrameworkCore;

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

        public void CancleReservation(int ReservationId)
        {
            reservationService.UpdateReservationStatus(ReservationId, ReservationStatus.Cancelled);
        }

        public List<RoomDTO> GetAvailableRooms(DateTime CheckIn,DateTime CheckOut)
        {
            var ReservedRoomIDs = reservationService.GetReservedRooms(CheckIn, CheckOut);
            var availableRooms = roomService.Get(r => !ReservedRoomIDs.Contains(r.Id)).ToList();
            return availableRooms;
        }

        public void MakeReservation(CreateResrvationDTO createResrvationDTO)
        {
            int ReservtionId = reservationService.AddReservation(createResrvationDTO);
            reservationService.UpdateReservationStatus(ReservtionId,ReservationStatus.Pending);
            List<RoomReservation> roomReservations = new List<RoomReservation>();

            foreach (var Room in createResrvationDTO.RoomDTOs)
            {
                roomReservations.Add(new RoomReservation { RoomId = Room.Id, ReservationId = ReservtionId });
            }
            roomReservationService.AddRange(roomReservations);
        }
    }
}
