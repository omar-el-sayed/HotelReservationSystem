
﻿using HotelReservationSystem.DTOs.Rooms;
﻿using HotelReservationSystem.DTOs;
using HotelReservationSystem.Models;
using System.Linq.Expressions;


namespace HotelReservationSystem.Services.Reservations
{
    public interface IReservationService
    {
        IEnumerable<RoomDTO> GetUnReservedRooms();
        List<ReservationDTO> Get(Expression<Func<Reservation, bool>> predicate);
    }
}
