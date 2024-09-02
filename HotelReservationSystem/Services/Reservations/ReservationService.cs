
using HotelReservationSystem.DTOs.Rooms;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;
using System.Linq.Expressions;
using HotelReservationSystem.Exceptions;
using HotelReservationSystem.DTOs.Reservations;

namespace HotelReservationSystem.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly IGenericRepository<Reservation> repo;

        public ReservationService(IGenericRepository<Reservation> repo)
        {
            this.repo = repo;
        }
        public IEnumerable<ReservationDTO> GetReservations()
        {
            return repo.GetAll().Map<ReservationDTO>();
        }
        public int AddReservation(CreateResrvationDTO createResrvationDTO)
        {
            var reservation = createResrvationDTO.MapeOne<Reservation>();
            repo.Add(reservation);
            repo.SaveChanges();
            return reservation.Id;
        }

        public List<ReservationDTO> Get(Expression<Func<Reservation, bool>> predicate)
        {
            var reservations = repo.Get(predicate).Map<ReservationDTO>();
            return reservations.ToList();
        }

        public List<int> GetReservedRooms(DateTime CheckIn, DateTime CheckOut)
        {
            bool Vaild = ValidateDate(CheckIn, CheckOut);
            if (!Vaild)
                throw new BusinessException(ErrorCode.InvalidDateRange, "Checkin date must be before checkout date.");

            var ReservedRooms = repo.Get(r => ((r.CheckinDate < CheckOut && r.CheckoutDate > CheckOut) || (r.CheckoutDate > CheckIn && r.CheckinDate < CheckIn)))
                .Map<ReservationDTO>();
            var ReservedRoomIDs = ReservedRooms.Where(r => r.Status != ReservationStatus.Cancelled)
                .SelectMany(r => r.RoomDTOs.Select(rr => rr.Id)).ToList();
            return ReservedRoomIDs;
        }

        public void UpdateReservation(ReservationDTO reservationDTO)
        {
            var reservation = repo.GetByIdWithTracking(reservationDTO.Id);
            if(reservation==null)
                throw new BusinessException(ErrorCode.DoesNotExist, $"Resrvation with id {reservation.Id} Not Exist ");

            reservationDTO.MapOne(reservation);
            repo.SaveChanges();
        }

        public void UpdateReservationStatus(int ReservationId,ReservationStatus reservationStatus)
        {
            var reservation = repo.GetByIdWithTracking(ReservationId);
            if(reservation==null)
                throw new BusinessException(ErrorCode.DoesNotExist, $"Resrvation with id {reservation.Id} Not Exist ");
            reservation.Status = reservationStatus;
            repo.SaveChanges();
        }

        public bool ValidateDate(DateTime CHeckIn, DateTime CheckOut)
        {
            if (CHeckIn >= CheckOut)
                return false;
            return true;
        }
    }
}
