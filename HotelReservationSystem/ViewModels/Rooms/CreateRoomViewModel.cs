﻿using HotelReservationSystem.DTOs;

namespace HotelReservationSystem.ViewModels.Rooms
{
    public class CreateRoomViewModel
    {
        public int Id { get; set; }
        public RoomType RoomType { get; set; }
        public decimal Price { get; set; }
        public int NumOfBed { get; set; }
        public int MaxOccupancy { get; set; }
        public double RoomSize { get; set; }
        public AvailableStatus AvailableStatus { get; set; }
        public int RoomNumber { get; set; }
        public List<PictureRoomDTO>? RoomPictures { get; set; }
        //public List<RoomFacilityDTO>? RoomFacilities { get; set; }
        public List<int>? FacilitiesIDS { get; set; }
    }
}
