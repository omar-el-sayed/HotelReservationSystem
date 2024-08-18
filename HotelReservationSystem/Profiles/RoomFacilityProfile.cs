﻿using AutoMapper;
using HotelReservationSystem.DTOs;
using HotelReservationSystem.Models;

namespace HotelReservationSystem.Profiles
{
    public class RoomFacilityProfile :Profile
    {
        public RoomFacilityProfile()
        {
            CreateMap<RoomFacility, RoomFacilityDTO>().ReverseMap();
        }
    }
}
