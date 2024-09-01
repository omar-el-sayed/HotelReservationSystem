
﻿using HotelReservationSystem.DTOs.Rooms;

﻿using HotelReservationSystem.DTOs;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;
using System.Linq.Expressions;
using HotelReservationSystem.Exceptions;

namespace HotelReservationSystem.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly IGenericRepository<Reservation> repo;

        public ReservationService(IGenericRepository<Reservation> repo)
        {
            this.repo = repo;
        }

        public int AddReservation(ReservationDTO reservationDTO)
        {
            var reservation = reservationDTO.MapeOne<Reservation>();
            repo.Add(reservation);
            repo.SaveChanges();
            return reservation.Id;
        }

        public List<ReservationDTO> Get(Expression<Func<Reservation, bool>> predicate)
        {
            var reservations = repo.Get(predicate).Map<ReservationDTO>();
            return reservations.ToList();
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

        public void UpdateReservation(ReservationDTO reservationDTO)
        {
            var reservation = repo.GetByIdWithTracking(reservationDTO.Id);
            if(reservation==null)
                throw new BusinessException(ErrorCode.DoesNotExist, $"Resrvation with id {reservation.Id} Not Exist ");

            reservationDTO.MapOne(reservation);
            repo.SaveChanges();
        }
    }
}
